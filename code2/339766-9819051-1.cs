    public static void WriteUTF(this BinaryWriter writer, string s)
    {
        short length = (short)Encoding.UTF8.GetByteCount(s);
        writer.Write(BitConverter.GetBytes(length).Reverse().ToArray());
        writer.Write(s.ToCharArray());
    }
