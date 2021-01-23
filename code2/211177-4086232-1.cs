            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            dic.Add("k1", new List<string>() { "1", "2", "3", "4", "5" });
            dic.Add("k2", new List<string>() { "7", "8" });
            dic.Add("k3", new List<string>());
            var max = dic.Max(x => x.Value.Count);
            dic.ToDictionary(
                kvp => kvp.Key,
                kvp =>
                {
                    if (kvp.Value.Count < max)
                    {
                        var cnt = kvp.Value.Count;
                        for (int i = 0; i < max - cnt; i++)
                            kvp.Value.Add("");
                    }
                    return kvp.Value;
                }).ToList();
