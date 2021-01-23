    using(var reader = new BinaryReader(file.InputStream))
        {
            using(var writer = new BinaryWriter( File.Open(newFilename, FileMode.CreateNew)))
            {
                var chunk = new byte[ChunkSize];
                Int32 count;
                while((count = reader.Read(chunk, 0, ChunkSize)) > 0)
                {
                    writer.Write(chunk, 0, count);
                }
            } // here we dispose of writer, which disposes of its inner stream
        } // here we dispose of reader
