    public class Something
    {
         private readonly DatabaseCatalog _dbsc;
         public Something(IOptions<DatabaseCatalog> dbsc)
         {
               _dbsc = dbsc.Value;
         }
    }
