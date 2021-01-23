    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    namespace Test.SendImageClient {
        public class Program {
            public static void Main(string[] args) {
                if (args.Length == 0) {
                    Console.WriteLine("usage: client imagefile");
                    return;
                }
                FileStream stream = File.OpenRead(args[0]);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("localhost", 8000);
                int length = IPAddress.HostToNetworkOrder((int)stream.Length);
                socket.Send(BitConverter.GetBytes(length), SocketFlags.None);
                byte[] buffer = new byte[1024];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) {
                    socket.Send(buffer, 0, read, SocketFlags.None);
                }
                socket.Close();
            }
        }
    }
