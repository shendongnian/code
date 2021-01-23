    byte[] binaryBuffer = null;
    using (MemoryStream compressedBody = new MemoryStream()) 
    {
        using(GZipStream stream = new GZipStream(compressedBody, CompressionMode.Compress))
        {
            Formatter.Serialize(compressedBody, message); 
            binaryBuffer = compressedBody.GetBuffer();
        }
    }
    using (MessageQueue l_Queue = CreateQueue())        
    {            
        l_QueueMessage.BodyStream.Write(binaryBuffer, 0, binaryBuffer.Length);
        l_QueueMessage.BodyStream..Seek(0, SeekOrigin.Begin);
        l_Queue.Send(l_QueueMessage);
    }
