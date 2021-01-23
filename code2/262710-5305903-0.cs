    public static IEnumerable<T> GetList<T>(this DataSet dataset) where T: new()
    {
      return dataset.Tables[0].AsEnumerable()
        .Select(r => {
          T t = new T();
          foreach (var prop in typeof(T).GetProperties())
          {
            prop.SetValue(t, r[prop.Name]);
          }
          return t;
        });
    }
