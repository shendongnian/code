    var d = new CaseDictionary<int>();
    d.Add("word", 1);
    d.Add("Word", 2);
    d.Add("WOrd", 3);
    d.Add("word2", 4);
    d.Add("worD2", 5);
    Console.WriteLine(d.ContainsKey("WOrd2"));
    Console.WriteLine(d.ContainsKeyCS("WOrd2"));
    Console.WriteLine(d.AtCS["word2"]);
    d.AtCS["word2"] = 6;
    Console.WriteLine(d.AtCS["word2"]);
    
    // Output is:
    //True
    //False
    //4
    //6
