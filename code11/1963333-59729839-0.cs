 c#
RuntimeTypeModel.Default[typeof(MyTestClass)][1].IsMap = true;
however, this is obviously inelegant, and *today* requires using an alpha build (we've been using it in production here at Stack Overflow for an extended period; I just need to get a release together - docs, etc).
Given that it *works*, I'm tempted to propose that we should soften #2 in v3.\*, such that while the *default* behavior remains the same, it would still check for `[ProtoMap(...)]` for custom types, and enable that mode. I'm on the fence about whether to soften #1.
I'd be interested in your thoughts on these things!
But to confirm: the following works fine in v3.\* and outputs `"B"` (minor explanation of the code: in protobuf, append===merge for root objects, so serializing two payloads one after the other has the same effect as serializing a dictionary with the combined content, so the two `Serialize` calls spoofs a payload with two identical keys):
 c#
static class P
{
    static void Main()
    {
        using var ms = new MemoryStream();
        var key = new MyTestKey { Value = "X" };
        RuntimeTypeModel.Default[typeof(MyTestClass)][1].IsMap = true;
        Serializer.Serialize(ms, new MyTestClass() { Dictionary = 
          new Dictionary<MyTestKey, string> { { key, "A" } } });
        Serializer.Serialize(ms, new MyTestClass() { Dictionary =
          new Dictionary<MyTestKey, string> { { key, "B" } } });
        
        ms.Position = 0;
        var val = Serializer.Deserialize<MyTestClass>(ms).Dictionary[key];
        Console.WriteLine(val); // B
    }
}
I think what I'd *like* is if, in v3.\*, it worked *without* the `IsMap = true` line, with:
 c#
[ProtoContract]
public class MyTestClass
{
    [ProtoMember(1)]
    [ProtoMap] // explicit enable here, because not a normal map type
    public Dictionary<MyTestKey, string> Dictionary { get; set; }
}
