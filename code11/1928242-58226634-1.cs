    public interface IPacketHandler
    {
        void HandlePacket(IPacket packet);
    }
    public abstract class PacketHandler<T> : IPacketHandler where T : IPacket
    {
        public abstract PacketType HandlesPacketType { get; }
        public void HandlePacket(IPacket packet)
        {
            if (packet is T concretePacket)
            {
                HandlePacket(concretePacket);
            }
        }
        protected abstract void HandlePacket(T packet);
    }
    public class FooPacketHandler : PacketHandler<FooPacket>
    {
        public override PacketType HandlesPacketType => PacketType.Foo;
        protected override void HandlePacket(FooPacket packet) { /* some logic that accesses FooProperty */ }
    }
    public class BarPacketHandler : PacketHandler<BarPacket>
    {
        public override PacketType HandlesPacketType => PacketType.Bar;
        protected override void HandlePacket(BarPacket packet) { /* some logic that accesses BarProperty */ }
    }
    public class PacketHandlerManager
    {
        public PacketHandlerManager(Library library, IEnumerable<IPacketHandler> packetHandlers)
        {
            foreach (var packetHandler in packetHandlers)
            {
                library.Bind(packetHandler.HandlesPacketType, packetHandler.HandlePacket);
            }
        }
    }
