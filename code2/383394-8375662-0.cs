    abstract class MyList<T>
    {
        private List<T> innerList = new List<T>();
        public T Find(int? id)
        {
            foreach(T obj in innerList)
            {
                if(Compare(id, obj))
                    return obj;
            }
            return default(T);
        }
        protected abstract bool Compare(int? id, T obj);
    }
