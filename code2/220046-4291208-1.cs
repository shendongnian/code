    class Parent<T>
    {    
        public event Action<T> NewItem;
    }
    abstract class Transition<T> : Parent<T> { }
    class Child : Transition<Child>
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
