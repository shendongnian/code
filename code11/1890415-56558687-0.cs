// store
using (var ms = new MemoryStream())
{
    var obj = new MyData
    {
        Name = name,
        Price = price,
        Number = number,
        TimeStamp = timeStamp,
    };
    Serializer.Serialize<MyData>(ms, obj);
    // older versions: cache.StringSet("somekey", (byte[])ms.ToArray());
    cache.StringSet("somekey", RedisValue.CreateFrom(ms));
}
// retreive
using (var ms = new MemoryStream((byte[])cache.StringGet("somekey")))
{
    var obj = Serializer.Deserialize<MyData>(ms);
    Console.WriteLine(obj.Name);
    Console.WriteLine(obj.Price);
    Console.WriteLine(obj.Number);
    Console.WriteLine(obj.TimeStamp);
}
with:
 c#
[ProtoContract]
public class MyData
{
    [ProtoMember(1)]
    public long TimeStamp { get; set; }
    [ProtoMember(2)]
    public string Name { get; set; }
    [ProtoMember(3)]
    public double Price { get; set; }
    [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
    public int Number { get; set; }
}
protobuf-net and SE.Redis work well together - they have the same author.
