    public IEnumerable<T> GetValues<T>() where T : struct
    {   
        if (!typeof(T).IsEnum) throw new InvalidOperationException("Generic type argument is not a System.Enum");
        return Enum.GetValues(typeof(T)).OfType<T>(); 
    } 
