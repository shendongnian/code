     Dictionary<int, Type> dictionary = new Dictionary<int, Type>();
     //fill the Dictionary with all int/Type-combinations
    {
     int objectType;
     Type type = dictionary[objectType];
     var genericMethodInfo = this.GetType().GetMethod("GetObject").MakeGenericMethod(type);
     object newObject = genericMethodInfo.Invoke(this, null);
     var objectInCorrectType = Convert.ChangeType(newObject, type);
    }    
    public T GetObject<T>() where T : new()
    {
     return new T();
    }
