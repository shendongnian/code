    private BlockingCollection<PrimaryPacket> Waiting =
        new BlockingCollection<PrimaryPacket>();
    private void ProcessPackets()
    {
        while (true)
        {
            PrimaryPacket e = Waiting.Take();
            Packets.TryAdd(((ulong)e.IPAddress << 32 | e.RequestID), e);
        }
    }
    public void AddPacket(PrimaryPacket e)
    {
        Waiting.Add(e);
    }
