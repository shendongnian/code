c#
#region Your Library
public enum PacketType
{
    ConnectionOpen,
    KeepAlive,
    ConnectionClose
}
public abstract class Packet
{
    public abstract PacketType PacketType { get; }
}
#endregion
#region Your Implementation
public class MyPacketForKeppAlive : Packet
{
    public override PacketType PacketType => PacketType.KeepAlive;
}
public class MyPacketConnectionOpen : Packet
{
    public override PacketType PacketType => PacketType.ConnectionOpen;
}
internal static void Main(string[] args)
{
    Packet[] packets = new Packet[]
        {
            new MyPacketForKeppAlive(),
            new MyPacketConnectionOpen()
        };
    foreach (Packet p in packets)
    {
        Console.WriteLine(p.PacketType);
    }
}
#endregion
