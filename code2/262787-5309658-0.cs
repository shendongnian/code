            Dictionary<int, string> lst = new Dictionary<int,string>(10);
            lst.Add(7, "MAX");
            lst.Add(2, "A");
            lst.Add(1, "A");
            lst.Add(8, "0");
            Dictionary<int, string> newList = (lst.OrderBy(x => x.Value).ThenBy(x => x.Key)).ToDictionary(x => x.Key,x=>x.Value);
