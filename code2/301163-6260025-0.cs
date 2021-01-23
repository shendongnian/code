    public class Foo<T> : BlockingCollection<T>
    {
        public new void Add(T item)
        {
            base.Add(item);
            base.Add(item);
        }
    }
