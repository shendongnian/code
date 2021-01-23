    DataTable GetDataTableFromCacheOrDatabase()
    {
       if(!HttpContext.Current.Cache.ContainsKey("secret key"))
       {
           DataTable dataTable = GetDataTableFromDatabase();
           HttpContext.Current.Cache["secret key"] = dataTable;
       }
       return HttpContext.Current.Cache["secret key"] as DataTable;
    }
