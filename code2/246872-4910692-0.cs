    public class MyClass<T>
    {
        private T instanceVariable; // automatically initialized
    
        public void MyMethod()
        {
            T localVariable;  // not automatically initialized
        }
    }
