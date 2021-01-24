        private static void ScanNetwork(int port)
        {
            string GetAddress(string subnet, int i)
            {
                return new StringBuilder(subnet).Append(i).ToString();
            }
            Parallel.For(0, 254, async i =>
            {
                string address = GetAddress("192.168.1.", i);
                using (var client = new TcpClient())
                {
                    try
                    {
                        await client.ConnectAsync(IPAddress.Parse(address), port).ConfigureAwait(false);
                        await Task.Delay(5).ConfigureAwait(false);
                        if (!client.Connected) return;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Success @{address}");
                        client.Close();
                    }
                    catch (SocketException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Failed @{address} Error code: {ex.ErrorCode}");
                    }
                }
            });
        }
