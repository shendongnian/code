    class SomeClass {
        public SomeClass(object s, object t) { }
    }
    static void Main()
    {
        var someCtor = typeof(SomeClass).GetConstructors()[0];
        Func<object[], object> factoryFunction = CreateObjectFactoryMethodWithCtorParams(someCtor, someCtor.GetParameters().Length);
        var obj = factoryFunction(new object[] {"A String", 123 });
    }
