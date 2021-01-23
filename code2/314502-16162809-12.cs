    public static T Instance() //~1800 ms
    {
        return new T();
    }
    public static T Instance() //~1800 ms
    {
        return new Activator.CreateInstance<T>();
    }
    public static readonly Func<T> Instance = () => new T(); //~1800 ms
    public static readonly Func<T> Instance = () => 
                                     Activator.CreateInstance<T>(); //~1800 ms
    //works for types with no default constructor as well
    public static readonly Func<T> Instance = () => 
                   (T)FormatterServices.GetUninitializedObject(typeof(T)); //~2000 ms
    
    public static readonly Func<T> Instance = 
         Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();  
         //~50 ms for classes and ~100 ms for structs
