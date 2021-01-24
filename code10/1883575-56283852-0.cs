    var Integers = new Integers{
        int1 = 50,
        int2 = 42,
        // etc. ...
    };
    foreach (var field in typeof(Integers).GetFields())
    {
        Console.WriteLine(field.GetValue(Integers));
    }
