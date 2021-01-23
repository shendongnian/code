    public static void AddObjects<T>(this ObjectSet<T> objectSet,
                                     IEnumerable<T> objects)
        where T : class // Note this bit
    {
         foreach (var item in objects)
         {
             objectSet.AddObject(item);
         }
    }
