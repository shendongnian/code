    Regex r = new Regex(@"\d");
    string[] testData = new string[] { "123XY", "12346", "WEPXY" };
    foreach (var s in testData)
    {
        bool isMatch = r.IsMatch(s);
        Console.WriteLine("Data: {0}, Is match: {1}", s, isMatch);
    }
    Console.ReadLine();
