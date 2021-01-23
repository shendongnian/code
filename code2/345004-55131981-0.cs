    public static List<Packet> Packets = new List<Packet>();
    public class Packet
    {
        public Packet()
        {
            Packets.Add(this);
        }
        public string packetName;
    }
    
    public Packet myPacket = new Packet();
    myPacket.packetName = "myPacket";
    
    public void SomeMethod()
    {
        int x = 0;
        foreach (Packet p in Packets)
        {
            if (p.packetName = "myPacket")
            {
                Packet myPacket = Packets[x];
                break;
            }
            x++;
        }
    }
