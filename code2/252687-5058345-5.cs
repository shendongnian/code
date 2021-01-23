        string str = "to title case";
        Char[] ca = str.ToCharArray();
        foreach(Match m in Regex.Matches(str, @"\b[a-z]"))
        {
            ca[m.Index] = Char.ToUpper(ca[m.Index]);
        }
        Console.WriteLine(new string(ca));
       
