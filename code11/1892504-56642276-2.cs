    [Test("new", "", true)]
    public string Test1(char[] input, int scale)
    {
       return new string(input);
    
    }
    
    [Test("Concat", "", false)]
    public string Test2(char[] input, int scale)
    {
       return string.Concat(input);
    }
