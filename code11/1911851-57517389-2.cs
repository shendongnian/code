    var someEnum = MyEnum.Three;
    
    if (someEnum.IsIn(MyEnum.One, MyEnum.Three))
    {
       Console.WriteLine();
    }
    
    var list = new[]
                  {
                     MyEnum.Three,
                     MyEnum.One
                  };
    
    if (someEnum.IsIn(list))
    {
       Console.WriteLine();
    }
