    class MyHashSet<T> : HashSet<T>
    {
        public T this[int index]
        {
            get
            {
                int i = 0;
                foreach (T t in this)
                {
                    if (i == index)
                        return t;
                    i++;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
