     public clas MyClass<T> : IPredefinedInterface<T>
     {
          public void DoSomething(T obj)
          {
               // It's now always T, eliminating the need for an exception
          }
     }
