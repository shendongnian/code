    public static int Copy(this BinaryWriter writer,Int16 value,int destinationIndex)
    {
        writer.Seek(destinationIndex, SeekOrigin.Begin);
        writer.write(value);
        return writer.BaseStream.Position;
    }
