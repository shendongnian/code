    public interface A : B
        {
        }
    
        public interface B : C
        {
        }
    
        public interface C
        {
        }
    
        public interface D
        {
        }
    
        public class MyType : A, D
        {
        }
