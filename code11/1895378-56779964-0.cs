    public class PacketPool
    {
        public ConcurrentQueue<Packet> pool = new ConcurrentQueue<Packet>(2000);
        public Packet CreatePacket(string method)
        {
            if (pool.TryDequeue(out Packet packet))
            {
                return packet;
            }
            return new Packet();
        }
        public void Recycle(Packet packet)
        {
            packet.Bits = 0;
            if (packet.Buffer.Length > 512)
                Array.Resize(ref packet.Buffer, 512);
            packet.Count = 0;
            packet.Flag = PacketFlags.None;
            packet.Fragmented = Fragment.NotFragged;
            packet.Proto = Protocol.Sequenced;
            packet.Ptr = 8;
            packet.Lead = 0;
            packet.SendType = SendType.Raw;
            pool.Enqueue(packet);
        }
    }
