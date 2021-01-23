        static void Append(Stream source, Stream target)
        {
            BinaryWriter writer = new BinaryWriter(target);
            BinaryReader reader = new BinaryReader(source);  
            writer.Write((long)source.Length);
            byte[] buffer = new byte[1024];
            int read;
            do
            {
                read = reader.Read(buffer, 0, buffer.Length);
                writer.Write(buffer, 0, read);
            }
            while (read > 0);
            writer.Flush();
        }
        static Stream ReadNextStream(Stream packed)
        {
            BinaryReader reader = new BinaryReader(packed);
            int streamLength = (int)reader.ReadInt64();
            MemoryStream result = new MemoryStream();
            byte[] buffer = new byte[streamLength];
            reader.Read(buffer, 0, buffer.Length);
            BinaryWriter writer = new BinaryWriter(result);
            writer.Write(buffer, 0, buffer.Length);
            writer.Flush();
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
