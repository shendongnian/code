    Func<T,bool>
  
            public static List<T> RemoveWhere<T>(this List<T> source, Func<T, bool > predicate)
            {
                if (source == null)
                {
                    throw new ArgumentNullException("source", "The sequence is null and contains no elements.");
                }
    
                if (predicate == null)
                {
                    throw new ArgumentNullException("predicate", "The predicate function is null and cannot be executed.");
                }
    
                // how to use predicate here???
                var result = new List<T>();
                foreach(var item in source)
                {
                    if(!predicate(item))
                    {
                        result.Add(item);
                    }
                }
    
                return result;
            }
