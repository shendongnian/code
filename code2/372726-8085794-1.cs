    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace SocketClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                var encoding = Encoding.UTF8;
                using (var connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    connector.Connect(new IPEndPoint(IPAddress.Loopback, 6767));
                    string value;
                    value = "1234";
                    Console.WriteLine("Press any key to send \"" + value + "\".");
                    Console.ReadKey();
                    SendString(connector, encoding, value);
                    value = "ABCDEFGH";
                    Console.WriteLine("Press any key to send \"" + value + "\".");
                    Console.ReadKey();
                    SendString(connector, encoding, value);
                    value = "A1B2C3D4E5F6";
                    Console.WriteLine("Press any key to send \"" + value + "\".");
                    Console.ReadKey();
                    SendString(connector, encoding, value);
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    connector.Close();
                }
            }
            static void SendString(Socket socket, Encoding encoding, string value)
            {
                socket.Send(BitConverter.GetBytes(encoding.GetByteCount(value)));
                socket.Send(encoding.GetBytes(value));
            }
        }
    }
