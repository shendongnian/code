    public void Caller() 
    {
        object x = GetValue();
        if ( x.GetType() == typeof(BaseUri) ) // I assume that BaseUri is also a class name
        {
            BaseUri baseUri = (BaseUri)x;
            // now you can use baseUri to initialize another variable in outer scopes ... or use it as a parameter to some method or ...
        }
        else if(x.GetType() == typeof(Category))
        {
            // the same logic of casting and using goes here too ...
        }
    }
