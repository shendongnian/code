    void DoStuff(int a, string b, string c, string d)
    {
        // Do your stuff...
    }
    void DoStuff(string parameters)
    {
        var split = parameters.Split(',');
        if (split.Length != 4)
              throw new ArgumentException("Wrong number of parameters in input string");
        int a;
        if (!int.TryParse(split[0], out a)
              throw new ArgumentException("First parameter in input string is not an integer");
        // Call the original
        this.DoStuff(a, split[1], split[2], split[3]);
    }
