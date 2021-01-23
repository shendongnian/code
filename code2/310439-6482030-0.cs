        public bool IsConnectedToInternet
        {
            try
            {
                using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                {
                    string address = @"http://www.google.com";//                        System.Net.NetworkInformation.PingReply pingReplay = ping.Send(address);//you can specify timeout.
                    if (pingReplay.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        return true;
                    }
                 }
            }
            catch
            {
    #if DEBUG
                System.Diagnostics.Debugger.Break();
    #endif//DEBUG
            }
    
            return false;
        }
