    public class YourContext: DbContext
    {
    
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured == false)
                options.UseMysql({YOUR_CONNECTION_STRING});
        }
    }
