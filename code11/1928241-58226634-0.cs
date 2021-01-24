    public enum PacketType
    {
        Foo,
        Bar
    }
    public interface IPacket
    {
        PacketType Type { get; }
    }
    public class FooPacket : IPacket
    {
        public PacketType Type => PacketType.Foo;
        public string FooProperty { get; }
    }
    public class BarPacket : IPacket
    {
        public PacketType Type => PacketType.Bar;
        public string BarProperty { get; }
    }
