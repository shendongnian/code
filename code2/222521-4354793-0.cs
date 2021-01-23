    class A<T> where T : IFoo 
    {
         public void DoSomething(T value)
         {
              value.Foo++;
         }
    }
