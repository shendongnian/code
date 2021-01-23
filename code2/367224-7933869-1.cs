    public class Foo
    {
        public static Foo New(string fooString)
        {
            ProxyGenerator generator = new ProxyGenerator();
            return (Foo)generator.CreateClassProxy
                 (typeof(Foo), new object[] { fooString }, new Interceptor()); 
        }
