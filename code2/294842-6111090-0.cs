    interface iMyInterface
    {
       
    }
    
    public static bool IsMixed<T>(this T obj) where T: iMyInterface
    {
       return obj.IsThis && obj.IsThat;
    } 
