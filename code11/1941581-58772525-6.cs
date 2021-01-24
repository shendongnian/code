    public static IServiceCollection AddRange(this IServiceCollection current, IServiceCollection main)
    {
        if(current == null)
        {
            throw ArgumentNullException();
        }
   
        foreach (var serv in main)
        {
            current.Add(serv);
        }
    
        return current;
    }
