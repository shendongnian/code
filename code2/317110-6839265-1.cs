    public static class WCFBugWorkaround
    {
        public static bool IsConnectionPossible(this ServiceHost host)
        {
            try
            {
                foreach (var baseAddress in host.BaseAddresses)
                {
                    IPAddress[] ipAddresses = Dns.GetHostAddresses(baseAddress.DnsSafeHost);
                    IPAddress ipAddr = ipAddresses.Where(e => e.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                    if (ipAddr == null)
                    {
                        return false;
                    }
                    using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        System.Net.IPEndPoint localEP = new IPEndPoint(ipAddr, baseAddress.Port);
                        s.Bind(localEP);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
    ServiceHost host = ...;
    ...
    if (host.IsConnectionPossible())
    {
        host.Open();
    }
