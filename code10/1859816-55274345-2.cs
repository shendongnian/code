        public static void Main(string[] args)
        {
          var foo = new Foo(42);
          var result = Task.Run(foo.CountToBillion).Result;
        }
    
        class Foo
        {
          public Foo(int someInput) { SomeInput = someInput; }
          public int SomeInput { get; set; }
          public int CountToBillion() { ... }
        }
