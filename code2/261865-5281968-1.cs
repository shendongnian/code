    if(MyClass.IsTrue()) // static call
    {
        var myObject = new MyClass(); // constructor call
        int result = myObject.GetNumber(); // instance member call
        Console.WriteLine(result);
    }
