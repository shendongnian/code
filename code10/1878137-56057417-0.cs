    while (bsonReader.State != BsonReaderState.EndOfArray)
    {
        var guid = new Guid(bsonReader.ReadBinaryData().Bytes);
        guids.Add(guid);
    }
    
    bsonReader.ReadEndArray();
