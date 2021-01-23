    public void Run()
    {
        var template = "{0} inches is {1} centimetres.";
        Console.WriteLine(template, 2.0, Inches2Centimetres(2.0));
        Console.WriteLine(template, 5.0, Inches2Centimetres(5.0));
    }
