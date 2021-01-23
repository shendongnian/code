    public class ClassOptions 
    { }
    public class ClassDerivedOptions : ClassOptions 
    { }
    
    public interface INode<T> where T : ClassOptions
    {
        T Options { get; }
    }            
    
    public class MyClass : INode<ClassOptions> 
    {
        public ClassOptions Options { get; set; }
    }           
    
    public class MyDerivedClass : INode<ClassDerivedOptions>
    {
        public ClassDerivedOptions Options { get; set; }
    }
