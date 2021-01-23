    private Dictionary<IPAddress,Session> activeSessions =  new Dictionary<IPAddress,Session>();
    
    private void packetReceived(Packet pkt)
    {
        Session curSession;
        if (!activeSessions.TryGetValue(pkt.SourceIP, out curSession))
        {
            curSession = new Session();
            activeSessions.Add(pkt.SourceIP, curSession);
        }
    
        curSession.ProcessPacket(pkt);
    }
