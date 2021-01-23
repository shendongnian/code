        public static Dictionary<string, string> PullFromConfigFile()
        {
            ParallelQuery<IEnumerable<string>> data;
            try
            {
                TextReader tr = new StreamReader("config.cfg");
                data = tr.ReadToEnd()
                    .Split('\n')
                    .AsParallel()
                    .Select(i => new string(i.TakeWhile(k => k != '#').ToArray()))
                    .Where(i => !i.IsNullOrWhiteSpace())
                    
                    .Select(i => i.Split('\t')
                        .Where(k => !k.IsNullOrWhiteSpace())
                        .Select(k => k.Trim())
                    ).Where(i => i.Count() == 2);
                tr.Close();
            }
            catch (IOException)
            {
                Logger.Bad("config.cfg file was not found");
                return new Dictionary<string, string>();
            }
            return ConfigParser.ParseIntoDict(data);
        }
        protected static Dictionary<string, string> ParseIntoDict(ParallelQuery<IEnumerable<string>> data)
        {
            var agg = new Dictionary<string, string>();
            foreach (var entry in data)
            {
                if (!agg.ContainsKey(entry.First()))
                    agg.Add(entry.First(), entry.Last());
            }
            var width = agg.Keys.Max(k => k.Length);
            agg.ForAll(i => Logger.Log("Loaded Data: {0} {1}",
                i.Key.SetWidth(width, '-'), i.Value));
            return agg;
        }
