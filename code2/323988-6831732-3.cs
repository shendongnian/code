    Public DataTable GetDataTableFromCacheOrDatabase()
    {
       DataTable dataTable = HttpContext.Current.Cache["secret key"] as DataTable;
       if(dataTable == null)
       {
           dataTable = GetDataTableFromDatabase();
           HttpContext.Current.Cache["secret key"] = dataTable;
       }
       return dataTable;
    }
