            Stream s = new MemoryStream();
            Stream outputStream = new MemoryStream();
            int BUFFER_SIZE = 1024;
            using (BinaryReader reader = new BinaryReader(s))
            {
                BinaryWriter writer = new BinaryWriter(outputStream);
                byte[] buffer = new byte[BUFFER_SIZE];
                int read = buffer.Length;
                while(read != 0)
                {
                    read = reader.Read(buffer, 0, BUFFER_SIZE);
                    writer.Write(buffer, 0, read);
                }
                writer.Flush();
                writer.Close();
            }
