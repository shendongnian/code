    HashSet<char> chars = new HashSet<char>();
    string s = "aabbcccddeefddg";
    foreach(char c in s)
    {
        chars.Add(c);
    }
    
    foreach(char c in chars)
    {
        Console.WriteLine(c);
    }
