    class SomeClass {
        public SomeClass(string s, int t) { }
    }
    static void Main()
    {
        var someCtor = typeof(SomeClass).GetConstructors()[0];
        Func<object[], object> factoryFunction = CreateObjectFactoryMethodWithCtorParams(someCtor);
        var obj = factoryFunction(new object[] {"A String", 123 });
    }
