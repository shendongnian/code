    private Dictionary<IPAddress,Session> activeSessions =  new Dictionary<IPAddress,Session>();
    
    private void packetReceived(Packet pkt)
    {
        Session curSession;
        if (activeSessions.ContainsKey(pkt.SourceIP))
        {
    	    curSession = activeSessions[pkt.SourceIP];
        }
        else
        {
            curSession = new Session();
            activeSessions.Add(pkt.SourceIP, curSession);
        }
    
        curSession.ProcessPacket(pkt);
    }
