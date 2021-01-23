    public class Baz : IFoo, IBar
    {
        IFoo foo = new Foo(); // or inject 
        IBar bar = new Bar(); // or inject
    
        public void A()
        {
            foo.A();
        }
    
        public void B()
        {
            bar.B();
        }
    }
