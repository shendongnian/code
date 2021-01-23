    public class Foo
    {
        // implemented by compiler
        public event EventHandler MyEvent;
    
        public static Foo FooFactory(EventHandler myEventDefault)
        {
           // setting the "event" : perfectly legal
           return new Foo { MyEvent = myEventDefault }; 
        }
    }
    public class Bar
    {
        public static Foo FooFactory(EventHandler myEventDefault)
        {
            // meaningless: won't compile
            return new Foo { MyEvent = myEventDefault };
        }
    }
    public class Baz
    {
        // custom implementation
        public event EventHandler MyEvent
        {      
            add { }  // you can imagine some complex implementation here
            remove { } // and here
        }
    
        public static Baz BazFactory(EventHandler myEventDefault)
        {
            // also meaningless: won't compile
            return new Baz { MyEvent = myEventDefault };
        }
    }
