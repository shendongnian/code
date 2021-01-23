    public Stream GetData()
    {
        MemoryStream stream = new MemoryStream();
        BinaryWriter writer = new BinaryWriter(stream); // Don't close at the end!
        writer.Write(2);
        writer.Write((short) 3);
        writer.Write((short) 3);
        writer.Write(2); // Extra count for the Single values
        writer.Write(4.4f);
        writer.Write(5.6f);
        writer.Flush(); // May not be required...
        stream.Position = 0; // Rewind so stream can be read again
        return stream;
    }
