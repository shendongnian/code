    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    namespace SocketHandleShareTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 5353);
                Socket sListen = new Socket(AddressFamily.InterNetwork, 
                                            SocketType.Stream, ProtocolType.Tcp);
                sListen.Bind(ep);
                sListen.Listen(10);
                Socket sClient = sListen.Accept();
                Console.WriteLine("DoStuffWithSocket() enter");
                Console.ReadLine();
                DoStuffWithSocket(sClient.Handle);
                Console.WriteLine("DoStuffWithSocket() exit");
                Console.ReadLine();
                sClient.Close();
                sListen.Close();
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
            [DllImport("UnmanagedSocketHandler.dll")]
            static extern void DoStuffWithSocket(IntPtr sock);
        }
    }    
