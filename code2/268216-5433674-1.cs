    public interface IDo
    { 
        Do();
    }
    public static class Foo
    {
        public static IList<T> Bar(this DataTable table) where T : IDo
        {
            IList<T> list = ... // do something with DataTable.
    
            foreach(T item in list)
            {
                item.Do();
            }
    
            return list;
        }
    }
