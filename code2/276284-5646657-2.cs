    using System.Net;
    using System.Net.Sockets;
    namespace SocketHandleShareTestClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] buf = new byte[40];
                Socket s = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Stream, ProtocolType.IP);
                s.Connect("localhost", 5353);
                int len = s.Receive(buf);
                Console.WriteLine("{0} bytes read.", len);
                if (len > 0)
                {
                    string data = Encoding.ASCII.GetString(buf, 0, len);
                    Console.WriteLine(data);
                }
                s.Close();
                Console.ReadLine();
            }
        }
    }
