    public class ClassWithNull<T>
    {
        private object varName_priv = null;
        
        public T varName { get { return (T)varName_priv; } }
    }
