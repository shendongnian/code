    public static class ConnectionExtension
    {
        public static IPAddress RemotePublicIpAddress(this ConnectionInfo connection)
        {
            if (!IPAddress.IsLoopback(connection.RemoteIpAddress))
            {
                return connection.RemoteIpAddress;
            }
            else
            {
                string externalip = new WebClient().DownloadString("http://icanhazip.com").Replace("\n","");
                return IPAddress.Parse(externalip);
            }
        }
    }
