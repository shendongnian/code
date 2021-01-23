        public void test()
        {
            string hostname = "google.com";
            IPAddress ipAdress;
            if (TryGetIpAddress(hostname, out ipAdress))
            {
                Console.WriteLine("Host:'{0}', IP:{1}.", hostname, ipAdress);
            }
            else
            {
                Console.WriteLine("Host '{0}' not found.", hostname);
            }
        }
        public bool TryGetIpAddress(string hostname, out IPAddress ipAddress)
        {
            const int HostNotFound = 11001;
            ipAddress = null;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                ipAddress = hostEntry.AddressList[0];
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode != HostNotFound) throw;
            }
            return (ipAddress != null);
        } 
