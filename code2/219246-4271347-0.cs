    public override Message ReadMessage(ArraySegment<Byte> buffer, BufferManager bufferManager, String contentType) {
        // Convert buffer to stream and pass to overload.
        byte[] msgContents = new byte[buffer.Count];
        Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
        bufferManager.ReturnBuffer(buffer.Array);
        MemoryStream stream = new MemoryStream(msgContents);
        return ReadMessage(stream, int.MaxValue);
    }
    public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType) {
        // The only new functionality in this class is to pass the stream through a 
        // StreamReader with the encoding set to *not* throw on invalid bytes. 
        XmlReader reader = XmlReader.Create(new StreamReader(stream, new UTF8Encoding(false, false)));
        return Message.CreateMessage(reader, maxSizeOfHeaders, MessageVersion);
    }
