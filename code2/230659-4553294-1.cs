    using System.Net.NetworkInformation;
    public void DoPing(string host, int packetSize, int packetCount)
    {
        int timeout = 1000;  // 1 second timeout.
        byte[] packet = new byte[packetSize];
        // Initialize your packet bytes as you see fit.
    
        Ping pinger = new Ping();
        for (int i = 0; i < packetCount; ++i) {
            pinger.Send(host, timeout, packet);
        }
    }
