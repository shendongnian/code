    var d = new CaseDictionary<int>();
    d.Add("word", 1);
    d.Add("Word", 2);
    d.Add("WOrd", 3);
    d.Add("word2", 4);
    d.Add("worD2", 5);
    Console.WriteLine(d.ContainsKey("WOrd"));
    Console.WriteLine(d.ContainsKey("WOrd2"));
    Console.WriteLine(d.ContainsKeyCI("WOrd2"));
    Console.WriteLine(d["word2"]);
    d["word2"] = 6;
    Console.WriteLine(d["word2"]);
    Console.WriteLine();
    foreach (var w in d.AtCI["word2"])
        Console.WriteLine(w);
