       class AB<T, U>
       {
          protected T t;
          U u;
       }
    
       class C<U> : AB<int, U>
       {
          public void Foo()
          {
             t = 5;
          }
       }
