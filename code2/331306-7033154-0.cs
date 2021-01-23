    class Foo
    {
         public Foo2 Parent { get; protected set; }
         public Foo(Foo2 parent)
         {
             Parent = parent;
         }
    }
    class Foo2
    {
          public Foo2()
          {
              List<Foo> x = new List<Foo>
              {
                  new Foo(this)
              };
          }
    }
