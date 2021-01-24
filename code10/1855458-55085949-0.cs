 c#
using ProtoBuf;
using ProtoBuf.Meta;
static class P
{
    static void Main()
    {
        // only need to do this once, *before*
        // serializing/deserialing anything
        RuntimeTypeModel.Default.Add(typeof(Amount), false)
            .SetSurrogate(typeof(AmountSurrogate));
        // test it works
        var obj = new Foo { Amount = new Amount(123.45M) };
        var clone = Serializer.DeepClone(obj);
        System.Console.WriteLine(clone.Amount.Value);
    }
}
[ProtoContract]
public class Foo
{
    [ProtoMember(1)]
    public Amount Amount { get; set; }
}
[ProtoContract]
struct AmountSurrogate
{ // a nice simple type for serialization
    [ProtoMember(1)]
    public long Value { get; set; }
    // operators define how to get between the two types
    public static implicit operator Amount(AmountSurrogate value)
        => Amount.CreateFrom(value.Value);
    public static implicit operator AmountSurrogate(Amount value)
        => new AmountSurrogate { Value = value.ScaledValue };
}
