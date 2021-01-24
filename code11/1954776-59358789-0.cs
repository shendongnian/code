    public static class MyClass
    {
        public static MyClass<string> Create(string s, int status)
        {
            return new MyClass<string>(s, status);
        }
    }
    
    ...
    
    var x = MyClass.Create("Foo", 0);
