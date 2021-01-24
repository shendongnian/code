    var e = DynamicExpressionParser.ParseLambda(
        typeof(MyInput),                 // input type
        typeof(MyOutput),                // output type
        "new (Id as id)");               // initialize properties
    // test
    MyOutput o = e.Compile().DynamicInvoke(new MyInput() { Id = 123 }) as MyOutput;
    Console.WriteLine(o.id);     // outputs 123
