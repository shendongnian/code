        var list = new ArrayList {"lol", 101};
        foreach (var value in list)
        {
            if(value is string s)
                Console.WriteLine(s);
            if (value is int i)
                Console.WriteLine(i);
        }
