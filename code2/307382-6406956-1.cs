    private static PacketHandler handler = new TalkPacket();
    public static void handlePacket(Player player, Packet p)
    {
        PacketHandler handler = null;
    
        if(idList.Contains(p.Id)) { // no need for dictionary, just array or list of int
            handler.handlePacket(player, p);  
        } else {
            Console.WriteLine("Unhandled packet: " + p + ".");
        }
    }
