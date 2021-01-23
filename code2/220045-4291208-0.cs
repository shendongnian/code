    abstract class Parent<T>
    {
        public event Action<T> NewItem;
    }
    class Child : Parent<Child>
    {
        public Child()
        {
            NewItem += OnNewItem;
        }
        private void OnNewItem(Child obj)
        {
            // Do something 
        }
    } 
