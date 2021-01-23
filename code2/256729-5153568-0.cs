            var list = new List<short>{1,2,3,4,5};
            using (var file = File.Create("my.data"))
            using (var writer = new BinaryWriter(file))
            {
                writer.Write(list.Count);
                foreach(var item in list) writer.Write(item);
            }
            using (var file = File.OpenRead("my.data"))
            using (var reader = new BinaryReader(file))
            {
                int count = reader.ReadInt32();
                list = new List<short>(count);
                for (int i = 0; i < count; i++)
                    list.Add(reader.ReadInt16());
            }
