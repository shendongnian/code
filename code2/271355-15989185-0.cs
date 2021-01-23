        static void Main(string[] args)
        {
            UdpClient u = new UdpClient(System.Net.Dns.GetHostName(), 1);
            IPAddress localAddr = (u.Client.LocalEndPoint as IPEndPoint).Address;
            NetworkInterface[] netIntrfc  = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < netIntrfc.Length - 1; i++)
            {
                if (netIntrfc[i].OperationalStatus == OperationalStatus.Up) 
                {
                    IPInterfaceProperties ipProps = netIntrfc[i].GetIPProperties();
                    foreach (UnicastIPAddressInformation uni in ipProps.UnicastAddresses) 
                    {
                        if (uni.Address.ToString() == localAddr.ToString()) 
                        {
                            Console.WriteLine("DEFAULT: " + netIntrfc[i].Name.ToString());
                            Console.WriteLine(netIntrfc[i].Id.ToString());
                        }
                    }
                } 
            }
        }
