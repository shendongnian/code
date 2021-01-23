    class Post
    {
        public uint PostId { get; set; }
    }
    static public void RegisterType<T>(Func<T, uint> getUintFromT)
    {
        Func<object, T> toT = (t => (T)t);
        Func<object, uint> getUintFromObject = 
            @object => getUintFromT(toT(@object));
        _typeMap.Add(typeof(T), getUintFromObject);
    }
    static public uint GetObjectId(object obj)
    {
        return _typeMap[obj.GetType()](obj);
    }
