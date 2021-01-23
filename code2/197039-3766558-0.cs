    public List<T> LoadData<T>(string sql, Action<IDataReader, T> fill) where T : new()
    {
      using( SqlCommand cmd = new SqlCommand(sql, conn) )
      using( SqlDataReader reader = cmd.ExecuteReader() )
      {
        List<T> items = new List<T>();
        while( reader.Read() )
        {
          T item = new T();
          fill(reader, item);
          items.Add(item);
        }
        return items;
      }
    }
