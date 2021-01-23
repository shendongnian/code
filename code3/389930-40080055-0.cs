     public static bool IsNullOrEmpty<T> (this ICollection<T> collection)
     {
        if (collection == null || collection.Count == 0)
            return true;
        else
           return collection.All(item => item == null);
     }
