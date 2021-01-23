    public static class ConfigParser
    {
        public static Dictionary<string, string> PullFromConfigFile()
        {
            ParallelQuery<Tuple<string, string>> data;
    
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
                    )
                    .Where(i => i.Count() == 2)
                    .Select(i => new Tuple<string, string>(i.First(), i.Last()));
    
                tr.Close();
            }
            catch (IOException)
            {
                Logger.Bad("config.cfg file was not found");
                return new Dictionary<string, string>();
            }
            return ConfigParser.ParseIntoDict(data);
        }
    
        private static Dictionary<string, string> ParseIntoDict(ParallelQuery<Tuple<string, string>> data)
        {
            var agg = new Dictionary<string, string>();
            foreach (var entry in data)
            {
                if (!agg.ContainsKey(entry.Item1))
                    agg.Add(entry.Item1, entry.Item2);
            }
    
            var width = agg.Keys.Max(k => k.Length);
            agg.ForAll(i => Logger.Log("Loaded Data: {0} {1}",
                i.Key.SetWidth(width, '-'), i.Value));
    
            return agg;
        }
    }
