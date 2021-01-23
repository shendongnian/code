        static void Main(string[] args)
        {
            // get the IPs from the database so you can iterate over them
            List<string> ips = new List<string>()
            {
                "google.com",
                "127.0.0.1",
                "stackoverflow.com"
            };
            foreach (var ip in ips)
            {
                WaitCallback func = delegate(object state)
                {
                    if (PingIP(ip))
                    {
                        Console.WriteLine("Ping Success");
                    }
                    else
                    {
                        Console.WriteLine("Ping Failed");
                    }
                };
                ThreadPool.QueueUserWorkItem(func);
            }
            Console.ReadLine();
        }
        public static bool PingIP(string IP)
        {
            bool result = false;
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(IP);
                if (pingReply.Status == IPStatus.Success)
                    result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
