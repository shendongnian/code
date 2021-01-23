        public class Foo
        {
            protected static class StaticClass
            {
                public static int Count { get; set; }
            }
    
            public virtual string GetBars()
            {
                return "I am Foo: " + StaticClass.Count++;
            }
        }
    
        public class FooToo:Foo
        {
            public override string GetBars()
            {
                return "I am Foo Too: " + StaticClass.Count++;
            }
        }
