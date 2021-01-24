 c#
while (!((msg = reader.ReadLine()).Equals("exit"))){
   Transaction tx = (Transaction)formatter.Deserialize(strm);
}
the reader consumes *more than just `"transaction\r\n`" - it consumes that line *and some undefined number of bytes from whatever comes after*. When when `BinaryFormatter` tries to read the stream, it finds itself half way through a message, and it explodes in a shower of sparks.
Ideally, limit yourself to *one serialization mechanism*. Meaning: lose  `StreamReader`/`StreamWriter` **completely** here.
If I could propose an alternative mechanism using protobuf-net and inheritance:
 c#
[ProtoContract]
[ProtoInclude(1, typeof(ShutdownMessage))]
[ProtoInclude(2, typeof(TransactionMessage))]
public abstract class MessageBase {} 
[ProtoContract]
public sealed class ShutdownMessage : MessageBase {}
[ProtoContract]
public sealed class TransactionMessage : MessageBase {
    // your data here
}
and now you can *send* any number of messages with:
 c#
public void Send(MessageBase message) {
    Serializer.SerializeWithLengthPrefix(strm, message, PrefixStyle.Base128);
}
and *receive* any number of messages with:
 c#
while (true) {
    var msg = Serializer.DeserializeWithLengthPrefix<MessageBase>(strm, PrefixStyle.Base128);
    if (msg is null || msg is ShutdownMessage) break; // all done
    switch (msg)
    {
        case TransactionMessage tx: ProcessTransaction(tx); break;
        // etc
    }
}
