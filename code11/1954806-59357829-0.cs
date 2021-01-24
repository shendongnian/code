    public class MyList<T> : List<T>
    {
        public new void Add(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("Item already exists");
            }
            base.Add(item);
        }
    }
