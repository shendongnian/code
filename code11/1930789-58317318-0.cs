    public class B<T> : IB<T>
    {
       public void Foo(T parameter)
       {
          var param = parameter;
          //...
       }
    }
    
    public class A<T>
    {
        public A(IEnumerable<IB<T>> collectionOfBs) {}
    
        public void foo(IEnumerable<T> param)
        {
           collectionOfBs.Zip(param, (b, t) => { b.Foo(t); return 0 });
        }
    }
