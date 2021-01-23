    public static List<T> GetList<T>(string connStr, string SQL,
          params SqlParameter[] prms) where T : new(), IDataEntity
    {
        .... 
        T item = new T();
        item.Load(reader);
        list.Add(item);
    }
