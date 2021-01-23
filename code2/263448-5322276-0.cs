    public static int SQLInsert<TEntity>(TEntity obj) where TEntity : class
    {
        var indexer = new object[0];
        foreach (var item in obj.GetType().GetProperties())
        {
            item.GetValue(obj,indexer);
        }
        return 1;
    }
  
