    MyEnum x = MyEnum.SomeValue;
    MyEnum y = (MyEnum)100; // Let's say this is undefined.
    
    EnumHelper.DoSomething(x); // generic type of MyEnum can be inferred
    EnumHelper.DoSomething(y); // same here
