       public const string REG_KEY_MINE = @"SOFTWARE\Mine\Test";
    
    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(REG_KEY_MINE, false))
    {
    
    	UDP_PORT = (int) key.GetValue("UdpPort", 43221);
    	TCP_PORT = (int) key.GetValue("TcpPort", 8005);
    }
