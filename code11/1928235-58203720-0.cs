C#
public interface IPacket
{
    int Size { get; }
    IPacketHandler GetPacketHandler();
}
public interface IPacketHandler {
    IHandleResult HandlePacket();
}
public interface IHandleResult
{
}
public class FooPacketHandler : IPacketHandler
{
    private FooPacket _fp;
    public FooPacketHandler(FooPacket fp)
    {
        _fp = fp;
    }
    public IHandleResult HandlePacket()
    {
        //  Stuff.
    }
}
public class FooPacket : IPacket
{
    public int Size => 10;
    public string FooProperty { get; set; }
    public IPacketHandler GetPacketHandler() => new FooPacketHandler(this);
}
Usage:
C#
var result = GetSomePacketFromSomewhere().GetPacketHandler().HandlePacket();
