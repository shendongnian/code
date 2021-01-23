    public class Foo : IDisposable
    {
        // use another specific interface here, like some IBar,
        // this is a sample, so I use IDisposable which I know is implemented by Bar
        private readonly IDisposable external;
        public Foo()
        {
            Console.WriteLine("Foo");
            external = Activator.CreateInstance(Type.GetType("AssemblyB.Bar, AssemblyB")) as IDisposable;
        }
        ... same code    
    }
