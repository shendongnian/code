    private Dictionary<Type, Func<object, uint>> _typeMap;
    public void RegisterType<T>(uint typeId, Func<T, uint> func)
    {            
        _typeMap[typeof(T)] = (o) => func((T)o);
    }
    public uint GetObjectId(object obj)
    {
        return _typeMap[obj.GetType()](obj);
    }
