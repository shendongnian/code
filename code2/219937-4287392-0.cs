    public static string TryGetRequestValue(this HttpRequest request, string stringArg)
    {
        string result = null;
        string[] keys = request.Params.AllKeys;
        if( keys.Contains<string>(stringArg) )
        {
            result = request.Params.Get(stringArg);
        }   
        return result;
    }
