    public static void HandlePacket(Player player, Packet p)
    {
        PacketHandler handler = null;
    
        if(idList.Contains(p.Id)) { // no need for dictionary, just array or list of int
            handler = new TalkPacket();
            handler.HandlePacket(player, p);  
        } else {
            Console.WriteLine("Unhandled packet: " + p + ".");
        }
    }
