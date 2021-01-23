    namespace NS
    {
        public class Foo
        {
            public Foo()
            {
                this.Bar = new List<Bar>();
            }
            public List<Bar> Bar {get;set;}
        }
        internal class Bar
        {
            public Bar()
            {
            }
        }
    }
