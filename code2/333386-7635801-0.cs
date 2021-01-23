    public List<Log> GetLoggingData(DateTime LogDate, string title)
    {
        DateTime enddate = new DateTime(LogDate.Year, LogDate.Month, LogDate.Day, 23, 59, 59)
    
        var query = from t in context.Logs
                    where t.Timestamp > date
                    where t.Timestamp < enddate
                    select t;
    
        return query.ToList();
    }
