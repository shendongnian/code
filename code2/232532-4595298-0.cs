    public Result MyMethod(string aString, string bString, MyDelegate a, MyDelegate b)
    {
        string methodName = MethodBase.GetCurrentMethod().Name;
        using (LogService log = LogFactory.Create())
        {
            try
            {
                 a();
                 log.Info(methodName, "Created entity xyz");
                 b();
            }
            catch (Exception ex)
            { 
                log.Error(methodName, ex.message);
            }
    
        }
    }
