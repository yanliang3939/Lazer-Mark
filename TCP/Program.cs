using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            IPAddress iPAddress = new IPAddress(new byte[] { 192, 168, 37, 1 });
            EndPoint point = new IPEndPoint(iPAddress, 5566);
            tcpServer.Bind(point);

            tcpServer.Listen(100);
            Console.WriteLine("ready");

            Socket cilientSocket = tcpServer.Accept();
            Console.WriteLine("link");

            string message = "hello";
            byte[] data = Encoding.UTF8.GetBytes(message);
            cilientSocket.Send(data);
            Console.WriteLine("send message:",message);

            byte[] data2 = new byte[1024];
            int length = cilientSocket.Receive(data2);
            string message2 = Encoding.UTF8.GetString(data2, 0, length);
            Console.WriteLine("reciieve a message:" + message2);


            Console.ReadKey();

        }
    }
}
