    protected DateTime EnsureValidDatabaseDate(DateTime dateToVerify)
    {
        if (dateToVerify < System.Data.SqlTypes.SqlDateTime.MinValue.**Value**)
        {
            return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        }
        else if (dateToVerify > System.Data.SqlTypes.SqlDateTime.MaxValue.**Value**)
        {
            return System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        }
        else
        {
            return dateToVerify;
        }
    }
