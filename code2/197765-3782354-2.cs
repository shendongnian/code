    public static T Hydrate<T>(this Dictionary<string, string> theDictionary, 
       T myObject = new T()) where T:new() //default/optional parameter is valid in 4.0 only
    {
       //var myObject = myObject ?? new T(); //alternative in 3.5 and previous
       foreach(string key in myDictionary.Keys)
       {
          var propInfo = typeof(T).GetProperty(key);
    
          if(propInfo == null) throw new ArgumentException("key does not exist");
          propInfo.SetValue(myObject, theDictionary[key], null);
       }
       return myObject;
    }
