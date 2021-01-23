    void Main()
    {
        Foo foo = new Foo();
        var args = new object[0];
        var method = typeof(Foo).GetMethod("DoSomething");
        dynamic dfoo = foo;
        var actions = new[]
        {
            new TimedAction("Direct", () => 
            {
                foo.DoSomething();
            }),
            new TimedAction("Dynamic", () => 
            {
                dfoo.DoSomething();
            }),
            new TimedAction("Reflection", () => 
            {
                method.Invoke(foo, args);
            })
    
        };
        TimeActions(1000000, actions);
    }
    
    class Foo{
        public void DoSomething(){}
    }
