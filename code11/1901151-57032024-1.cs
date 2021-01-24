    var dict1 = new Dictionary<string, int>();
    dict1.Add("alex", 10);
    dict1.Add("liza", 10);
    dict1.Add("harry", 20);
    var dict2 = new Dictionary<string, int>();
    dict2.Add("alex", 5);
    dict2.Add("liza", 4);
    dict2.Add("harry", 1);
    var dict3 = new Dictionary<string, int>(dict1.Count);   // Thanks, @mjwills!
    foreach (var pair in dict1)
    {
        dict3.Add(pair.Key, pair.Value - dict2[pair.Key]);
    }
