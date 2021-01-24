    public class BadPacketHandler: IPacketHandlerTag
    {
        public void HandlePacket(string packet)
        {
            Console.WriteLine("Handling string");
        }
    }
