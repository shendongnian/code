    public static void Main(string[] args)
    {
        var obj1 = new myObject();
        obj1.Prop1 = 1;
        obj1.Prop2 = 1;
        obj1.Prop3 = 1;
        Console.WriteLine(obj1.AreTheyEqual());    // True;
        obj1.Prop3 = 5;
        Console.WriteLine(obj1.AreTheyEqual());    // False;
    }
