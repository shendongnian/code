 c#
public class Transaction {
    public int Id {get;set;}
    public string Name {get;set;}
}
might become
 c#
[ProtoContract]
public class Transaction {
    [ProtoMember(1)]
    public int Id {get;set;}
    [ProtoMember(2)]
    public string Name {get;set;}
}
After that, the code *should* be simply:
 c#
Serializer.Serialize(strm, tx); // this is ProtoBuf.Serializer
// and now close the "send" pipe; fine to leave the "receive" pipe, though
and
 c#
Serializer.Deserialize<Transaction>(strm); // again, ProtoBuf.Serializer
However! There's something slightly odd in play, as *as far as I can see*, the code shown in the question should work, unless something odd is happening.
---
Note: if you are sending *multiple* payloads (i.e. you need to partition it into frames), or if you don't want to have to worry about closing the send pipe, then:
 c#
Serializer.SerializeWithLengthPrefix(strm, tx, PrefixStyle.Base128);
and
 c#
Serializer.DeserializeWithLengthPrefix<Transaction>(strm, PrefixStyle.Base128);
