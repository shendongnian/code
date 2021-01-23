    public void Run()
    {
        Func<double, double> inches2Centimetres = inches => inches * 2.54;
        var template = "{0} inches is {1} centimetres.";
        Console.WriteLine(template, 2.0, inches2Centimetres(2.0));
        Console.WriteLine(template, 5.0, inches2Centimetres(5.0));
    }
