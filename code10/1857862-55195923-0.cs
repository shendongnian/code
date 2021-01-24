    public class Item
    {
        private readonly object _locker = new object();
        public void Foo()
        {
            lock (_locker)
            {
                // perform calcs
            }
        }
    }
    void foo(string key)
    {
        // the getItem may also require protection but on the collection level
        Item item = getItem(key);
        item?.Foo();
    }
