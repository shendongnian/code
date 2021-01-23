    public class MyClass<T>
    {
        public T this[int index]
        {
            get
            {
                return default(T);
            }
            set
            {
            }
        }
        public void MyMethod(int index)
        {                 
             T value = this[index];     
        }           
    }
