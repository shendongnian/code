    [TestMethod]
    public void DictionaryTest()
    {
     var item = new SomeCLass { Id = "1", Name = "name1" };
     IDictionary<string, object> dict = ObjectToDictionary<SomeCLass>(item);
     var obj = ObjectFromDictionary<SomeCLass>(dict);
    }
    
    
     private T ObjectFromDictionary<T>(IDictionary<string, object> dict) where T : class 
     {
      Type type = typeof(T);
      T result = (T)Activator.CreateInstance(type);
      foreach (var item in dict)
      {
       type.GetProperty(item.Key).SetValue(result, item.Value, null);
      }
       return result;
      }
    
      private IDictionary<string, object> ObjectToDictionary<T>(T item) where T: class
      {
       Type myObjectType = item.GetType();
       IDictionary<string, object> dict = new Dictionary<string, object>();
       var indexer = new object[0];
       PropertyInfo[] properties = myObjectType.GetProperties();
       foreach (var info in properties)
       {
        var value = info.GetValue(item, indexer);
        dict.Add(info.Name, value);
       }
        return dict;
       }
