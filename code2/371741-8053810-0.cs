    public static AceDataObjectCollection<T> ToAceDataObjectCollection<T>(this IEnumerable<T> col) where T : IAceDataObject 
    {    
       AceDataObjectCollection<T> objects = new AceDataObjectCollection<T>();
       
       foreach (T item in col)
          objects.Add(item);
        
       return objects; 
    }
