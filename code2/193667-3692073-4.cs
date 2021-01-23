    public class Foo
    {
       private Foo()
       {
          // do some low level initialization here
       }
       public Foo(int x, int y)
          : this()
       {
          // ...
       }
       public Foo(int x, int y, int z)
          : this()
       {
          // ...
       }
    }
