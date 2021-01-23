    Dictionary<string, string> dic = new Dictionary<string, string>(); // base data
    dic.Add("FaceBook", "Dingens");
    dic.Add("SocialMedia", "FaceBook");
    dic.Add("Medium", "SocialMedia");
            
    var list = new List<Tuple<string, string>>();  // result
    foreach (var de in dic)
    {
        var value = de.Value;
        do
        {
            list.Add(Tuple.Create(de.Key, value));
        } while (dic.TryGetValue(value, out value));
    }
    foreach (var x in list)
        Console.WriteLine(x.Item1 + ": " + x.Item2);
