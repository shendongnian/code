    var keys = dict1.Keys.Union(dict2.Keys).Union(dict3.Keys).Union(dict4.Keys);
    var result = new Dictionary<string,List<string>>();
    foreach(var key in keys) {
        List<string> list = new List<string>();
        list.Add(dict1.ContainsKey(key) ? dict1[key] : "");
        list.Add(dict2.ContainsKey(key) ? dict2[key] : "");
        list.Add(dict3.ContainsKey(key) ? dict3[key] : "");
        list.Add(dict4.ContainsKey(key) ? dict4[key] : "");
        result.Add(key, list);
    }
