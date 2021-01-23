    public static class Foo
    {
        public static IList<T> Bar(this DataTable table, Action<T> postProcess)
        {
            IList<T> list = ... // do something with DataTable.
    
            foreach(T item in list)
            {
                postProcess.Inoke(item);
            }
    
            return list;
        }
    }
