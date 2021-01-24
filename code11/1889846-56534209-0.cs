    public void Add(double a, double b)
    {
        var temp = a + b;
        Console.WriteLine("Sum:{0}", temp);
        result.Push(temp);
        total += temp;
    }
