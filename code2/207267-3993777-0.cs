    public class Foo
    {
        public event EventHandler MyEvent;
    
        public static Foo FactoryMethod(EventHandler myEventDefault)
        {
           // setting the "event" : perfectly legal
           return new Foo { MyEvent = myEventDefault }; 
        }
    }
