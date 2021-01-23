    var text = @"Some example that contains S 33 58.254 E 023 53.269 
                      and also S 22 58.123 W 021 53.2";
    var pattern = @"([SN])\s(\d+)\s(\d+(?:\.\d+)?)\s([EW])\s(\d+)\s(\d+(?:\.\d*)?)";
    var m = Regex.Matches(text, pattern);
    for (int i = 0; i < m.Count; i++) {
        Console.WriteLine("GPS Found: {0}", m[i].Value);
        Console.WriteLine("-----");
        Console.WriteLine(m[i].Groups[1].Value);
        Console.WriteLine(m[i].Groups[2].Value);
        Console.WriteLine(m[i].Groups[3].Value);
        Console.WriteLine(m[i].Groups[4].Value);
        Console.WriteLine(m[i].Groups[5].Value);
        Console.WriteLine(m[i].Groups[6].Value);
        Console.WriteLine("-----");
    }
