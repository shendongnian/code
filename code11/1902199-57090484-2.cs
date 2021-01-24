            public static Task<string[]> GetAllLocalIPv4(NetworkInterfaceType _type)
            {
                return Task.Factory.StartNew(() =>
                {
                    var output = new List<string>();
                    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface item in networkInterfaces.Where(item => item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up))
                    {
                        Parallel.ForEach(item.GetIPProperties().UnicastAddresses, (ip) =>
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                output.Add(ip.Address.ToString());
                            }
                        });
                    }
                    return output.ToArray();
                });
            }
