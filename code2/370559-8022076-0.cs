    public interface MyInterface
    {
        int property;
    }
    
    public interface A : MyInterface
    {
        void MyMethod();
    }
    
    public class AClass : A
    {
        public void MyMethod() { ... }
        int property;
    }
    
    public interface B : MyInterface
    {
        ICollection<int> MyMethod();
    }
    
    public class BClass : B
    {
        public ICollection<int> MyMethod() { ... }
        int property;
    }
