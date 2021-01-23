    class Foo
    {
        Foo(Baz baz)
        {
             bar = new Bar(baz);
        }
    
        Frob()
        {
             bar.Blah()
        }
    }
    
    class Bar
    {
         Bar(Baz baz);
    
         void blah()
         {
              baz.biz();
         }
    }
