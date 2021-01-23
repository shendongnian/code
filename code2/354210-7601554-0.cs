    Dictionary<Type, Action<object>> typeMap = new Dictionary<Type, Action<object>>();
    typeMap[typeof(Type1)] = item => DoType1(item as Type1);
    typeMap[typeof(Type2)] = item => DoType2(item as Type2);
    
    var actionMappedQuery =
      from item in source
      let type = item.GetType()
      where typeMap.ContainsKey(type)
      select new
      {
        input = item;
        method = typeMap[type]
      };
    
    foreach(var x in actionMappedQuery)
    {
      x.method(x.input);
    }
