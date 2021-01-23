       class Foo
       {
            public readonly int bar;
            Foo(int b)
            {
                 bar = b;  // readonly assignments only in constructor
            }
       }
        
       Foo x = new Foo(0);
