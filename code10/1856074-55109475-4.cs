    public static T CreateStyle<T>(string name) where T : BaseStyle
    {       
        try
        {
            return Activator.CreateInstance(typeof(T), new [] { name } );
        }
        catch(MissingMethodException exception)
        {
            throw new InvalidOperationException("The specified style does not have an appropriate constructor to be created with this factory.", exception);      
        }    
    }
