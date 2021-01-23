    // Description   -> |Identifier|name length|message length|    name   |    message   |
    // Size in bytes -> |     4    |     4     |       4      |name length|message length|
    using (var stream  = new MemoryStream(yourByteBuffer))
    {
       using (reader = new BinaryReader(stream))
       {
           var identifier = reader.ReadInt32();
           var nameLength = reader.ReadInt32();
           var msgLength = reader.ReadInt32();
           var name = reader.ReadChars(nameLength);
           var msg = reader.ReadChars(msgLength);
       }
    }
    // to get a string from the chars:
    var message = new string(msg);
