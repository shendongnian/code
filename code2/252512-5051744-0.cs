    FileStream fs = new FileStream(...);
    BinaryWriter fileWriter = new BinaryWriter(fs);
    
    // Allocate byte array big enough to hold the longest record
    byte[] RecordBuffer = new byte[MaxRecordSize];
    int recordLength;  // to get the number of bytes in a record.
    
    // for each record
    using (var ms = new MemoryStream())
    {
        using (var memWriter = new BinaryWriter(ms, Encoding.UTF8))
        {
            // write things to the memory stream
            memWriter.Write(myStringValue);
            memWriter.Write(myLongValue);
            // ... etc.
            // Now get the number of bytes written
            memWriter.Flush();
            recordLength = memWriter.Position;
        }
    }
    
    // The record is now serialized in RecordBuffer, from 0 to recordLength-1
    // Do your encryption.
    // Then write a count of bytes, and the buffer:
    fileWriter.Write(recordLength);
    fileWriter.Write(RecordBuffer, 0, recordLength);
