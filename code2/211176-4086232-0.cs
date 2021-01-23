        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        dic.Add("k1", new List<string>() { "1", "2", "3", "4", "5" });
        dic.Add("k2", new List<string>() { "7", "8" });
        dic.Add("k3", new List<string>());
        var max = dic.Max(x => x.Value.Count);
        foreach (var kv in dic)
        {
            if (kv.Value.Count < max)
            {
                var cnt = kv.Value.Count;
                for (int i = 0; i < max - cnt; i++)
                    kv.Value.Add("");
            }
                
        }
