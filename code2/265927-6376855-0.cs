    static List<T[]> groups<T>(IList<T> original, uint n)
        {
            Debug.Assert(n > 0);
            var listlist = new List<T[]>();
            var list = new List<T>();
            
            for (int i = 0; i < original.Count(); i++)
            {
                var item = original[i];
                list.Add(item);
                if ((i+1) % n == 0 || i == original.Count() - 1)
                {
                    listlist.Add(list.ToArray());
                    list.Clear();
                }
            }
         return listlist;
        }
