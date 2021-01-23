    public class Foo<T>
    {
      public T MyField { get; set; } 
    }
    
    public class FooInt : Foo<int>
    {
    }
    
    public class FooShort : Foo<short>
    {
    }
