    public class Foo
    {
        public virtual string Name { get; protected set; }
        public Foo()
        {
            Name = "Foo";
        }
    }
    class FooInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method == typeof(IEnumerable<char>).GetMethod("GetEnumerator")
                || invocation.Method == typeof(IEnumerable).GetMethod("GetEnumerator"))
                invocation.ReturnValue = ((Foo)invocation.Proxy).Name.GetEnumerator();
            else
                invocation.Proceed();
        }
    }
    …
    var proxy = new ProxyGenerator().CreateClassProxy(
        typeof(Foo), new[] { typeof(IEnumerable<char>) }, new FooInterceptor());
    Console.WriteLine(((Foo)proxy).Name);
    foreach (var c in ((IEnumerable<char>)proxy))
        Console.WriteLine(c);
