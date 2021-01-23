        public static object GetObjectAt(IEnumerable enumerable, int index)
        {
            int i = 0;
            foreach (object obj in enumerable)
            {
                if (i == index)
                    return obj;
                i++;
            }
            throw new IndexOutOfRangeException();
        }
