            using (var file = File.Create("Data.bin")) {
                Serializer.Serialize<IEnumerable<Asset>>(file, Generate(10));
            }
            using (var file = File.OpenRead("Data.bin")) {
                var ps = Serializer.DeserializeItems<Asset>(file, PrefixStyle.Base128, 1);
                int i = ps.Count(); // got them all back :-)
            }
