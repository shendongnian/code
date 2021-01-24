    private static T MapAuditFields<T>(T requestObj, long id , bool isNew )
    {
       
        if (isNew)
        {
            typeof(T).GetProperty("id").SetValue(request, DateTimeHelper.GetCurrentUTCDateTime());
            typeof(T).GetProperty("xxxxx").SetValue(request, DateTimeHelper.GetCurrentUTCDateTime());
    
            ...
        }
        else
        {
            typeof(T).GetProperty("id").SetValue(request, DateTimeHelper.GetCurrentUTCDateTime());
            typeof(T).GetProperty("xxxxxx").SetValue(request, DateTimeHelper.GetCurrentUTCDateTime());
        }
    
        return (T)result;
    }
