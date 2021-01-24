    private static T MapAuditFields<T>(long id , bool isNew, T t ) where T : new()
    {
        dynamic result = t;
        if (isNew)
        {
            result.xxxxxx = DateTimeHelper.GetCurrentUTCDateTime();
            result.xxxxxx = DateTimeHelper.GetCurrentUTCDateTime();
            result.xx= id;
            result.xx= id;
        }
        else
        {
            result.xxxxx= id;
            result.xxxxxx= DateTimeHelper.GetCurrentUTCDateTime();
        }
        return (T)result;
    }
