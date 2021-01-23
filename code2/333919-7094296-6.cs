     public override DbDataAdapter CreateDataAdapter()        
     {
         return tail.CreateDataAdapter();        
     }
Now the problem isn't exactly with this code but the fact that when Microsoft.Practices.EnterpriseLibrary.Data.Database class calls an intance of DbDataAdapter (tail in our case is SqlClientFactory) it creates SqlClientFactory Command, and then tries to set the Connection of this command to ProfiledDbConnection and this is were it breaks. 
