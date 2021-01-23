        IEnumerable <Bar> _bars;
        public void Qux()
        {
           foreach (var bar in _bars)
           {
               bar.Baz();
           }
        }
        /* rest of the implmentation of Foo */
    }
    
    public class Bar
    {
        Foo _parent;
        public void Baz()
        {
        /* do something here */
        }
        /* rest of the implmentation of Bar */
    }
