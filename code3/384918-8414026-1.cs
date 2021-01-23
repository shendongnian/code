    public interface IWithSomeField
    {
         int UserId { get; set; }
    }
    
    public class SomeGenericClasss<T> 
      : where T : IWithSomeField
    {
    
    }
    public class ClassA : IWithSomeField // Can be used in SomeGenericClass
    {
         int UserId { get; set; }
    }
    public class ClassB  // Can't be used in SomeGenericClass
    {
        
    }
