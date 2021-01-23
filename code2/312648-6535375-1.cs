    void Main()
    {
    	var source = new[] { "2" };
        Money thisWorks = source.Sum(x => Money.Parse(x));
        int thisWorksToo = source.Sum(new Func<string, int>(x => int.Parse(x)));
        var thisDoesNot = source.Sum(x => int.Parse(x));
    
        Console.Write(thisDoesNot.GetType());
    }
