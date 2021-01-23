    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    
    namespace CheckPortStatus
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    TcpClient tcp = new TcpClient();
                    tcp.Connect("localhost", Convert.ToInt16(1433));
                    Console.WriteLine("online");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("offline");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
