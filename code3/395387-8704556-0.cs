    public abstract class GenericBase<T> where T : MyClass
    {
        T SomeProperty{ get; set; }
    }
    
    public class Foo<T> where T : MyClass
    {
        T SomeProperty{ get; set; }
    }
    
    public abstract class GenericChild<T> : GenericBase<T> where T : MyClass
    {
    }
