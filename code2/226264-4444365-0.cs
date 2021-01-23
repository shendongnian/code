    public class SomeClass<T>
    {
        public List<T> Items { get; private set; }
        public void DoSomething()
        {
            T first = Items[0];
            ...
        }
    }
