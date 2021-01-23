    public class MyList<T> : List<T>
    {
        public new MyList<T> Add(T item)
        {
            base.Add(item);
            return this;
        }
    }
