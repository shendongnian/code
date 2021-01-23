    var linesInFile = File.ReadAllLines("c:\path\to\yourfile.txt");
    var dict = new Dictionary<string, int>();
    foreach(var line in linesInFile)
    {
        var parts = string.Split(new char[] {'|'});
        var item = parts[0];
        var amount = int.Parse(parts[1]);
        if(dict.HasKey(item)){
            dict[item] += amount;
        }else{
            dict.Add(item, amount);
        }
    }
    foreach(var kvp in dict)
    {
         Console.WriteLine(string.Format("{0}: {1}", kvp.Key, kvp.Value));
    }
