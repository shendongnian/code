    abstract class MyList
    {
        private List<Object> innerList = new List<Object>();
        public Object Find(int? id)
        {
            foreach(Object obj in innerList)
            {
                if(Compare(id, obj))
                    return obj;
            }
            return default(Object);
        }
        protected abstract bool Compare(int? id, Object obj);
    }
