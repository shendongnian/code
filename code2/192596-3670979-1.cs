    public class MyClass<T>
    {
        List<T> _items = new List<T>();
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
        }
        public void MyMethod()
        {
            T value = this[2];
        }
    }
