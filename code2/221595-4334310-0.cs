    public enum PacketType {Login, Hello, FooBar}
    public class Packet
    {
        public long Size;
        public PacketType PacketType;
    }
    public class LoginPacket : Packet
    {
        public string Login;
        public string Password;
    }
