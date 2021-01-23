    public static class myclass
        {
            public static Byte[] ToByteArray(this Stream stream)
            {
                Int32 length = stream.Length > Int32.MaxValue ? Int32.MaxValue : Convert.ToInt32(stream.Length);
                Byte[] buffer = new Byte[length];
                stream.Read(buffer, 0, length);
                return buffer;
            }
    
        }
