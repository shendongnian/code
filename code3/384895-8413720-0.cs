    class SomeType 
    {
        void Foo(int size, string bar) { }
        void Foo() { }
    }
    SomeType obj = new SomeType();
    // call with int and string arguments
    obj.GetType().GetMethod("Foo", new Type[] { typeof(int), typeof(string)).Invoke(obj, new object[] { 42, "Hello" });
    // call without arguments
    obj.GetType().GetMethod("Foo", new Type[0]).Invoke(obj, new object[0]);
