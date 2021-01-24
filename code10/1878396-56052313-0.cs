    interface IDatasourceProvider
    {
        void Save();
    }
    class FilesystemDatasource : IDatasourceProvider
    {
       void Save()
       {
          // save to disk
       }
    }
   
    class SqlServerDatasource : IDatasourceProvider
    {
       void Save()
       {
          // save to sql server
       }
    }
