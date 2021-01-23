    public class FList<T> : List<T>
    {
        public new FList<T> Add(T item)
        {
            base.Add(item);
            return this;
        }
        public new FList<T> RemoveAt(int index)
        {
            base.RemoveAt(index);
            return this;
        }
        // etc...
    }
    {
         var list = new FList<string>();
         list.Add("foo").Add("remove me").Add("bar").RemoveAt(1);
    }
