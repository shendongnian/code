      protected static object _lockObj = new object();
      if(_dictionary.ContainsKey(key))
      {
          return _dictionary[key];
      }
      else
      {
          lock(_lockObj)
          {
               if(_dictionary.ContainsKey(key))
                  return _dictionary[key];
               _dictionary.Add(key, "someValue");
               return "someValue";
          }
      }
