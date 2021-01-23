    class Parent<T> where T : Parent<T>
    {
        protected event Action<T> NewItem;
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
