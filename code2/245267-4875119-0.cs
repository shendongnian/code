    public abstract class MyClass<T>
    {
       public T MyValue{ get; set;}
    }
    
    public class MyIntClass : MyClass<int>
    {}
    
    public class MyLongClass : MyClass<long>
    {}
