    class Foo
    {
         string bar;
         int baz;
         
         public Foo(string bar)
         {
              this.bar = bar;
              // ---^ class field
              // ---------^ parameter
              int baz = 42; // local
              this.baz = baz; // assigns local value to class field
         }
    }
