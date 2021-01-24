C#
public interface IPacketProducer<out T> where T : IPacket
{
    T ProducePacket();
}
`IPacketProducer<FooPacket>.ProducePacket()` *is* guaranteed to return something that implements IPacket. But that doesn't address your problem, because you're handling packets, not creating them. 
Here's how I might do it. Whether this works for your case will depend on exactly what you need from packet handling, and how much you need to decouple packets from their handlers. The basic principle is: When you've got an `IPacket`, there's a concrete class instance behind it that knows exactly what he is. So whatever you need to do that depends on his actual type, just ask him. 
Maybe `HandlePacket()` or `GetPacketHandler()` or both should have parameters, maybe `HandlePacket()` doesn't need to return anything. 
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
All the generics were doing for you was antagonizing the compiler. Just because you've got a hammer doesn't mean you need to eat your eggs with it. 
