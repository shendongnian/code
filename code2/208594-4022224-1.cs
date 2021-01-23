        static void Serialize(string path, IDictionary<string, int> data)
        {
            using (var file = File.Create(path))
            using (var deflate = new DeflateStream(file, CompressionMode.Compress))
            using (var writer = new BinaryWriter(deflate))
            {
                writer.Write(data.Count);
                foreach(var pair in data)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);                    
                }
            }
        }
        static IDictionary<string,int> Deserialize(string path)
        {
            using (var file = File.OpenRead(path))
            using (var deflate = new DeflateStream(file, CompressionMode.Decompress))
            using (var reader = new BinaryReader(deflate))
            {
                int count = reader.ReadInt32();
                var data = new Dictionary<string, int>(count);
                while(count-->0) {
                    data.Add(reader.ReadString(), reader.ReadInt32());
                }
                return data;
            }
        }
