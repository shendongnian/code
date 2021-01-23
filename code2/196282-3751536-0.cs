    List<string> item = new List<string>();
                item.Add("a");
                item.Add("as");
                item.Add("b");
                item.Add("fgs");
                item.Add("adsd");
    
                var res1 = item.FindAll(i => i.StartsWith("a"));
                var res2 = item.Where(i => i.StartsWith("a"));
