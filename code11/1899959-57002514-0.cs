    public interface IDbContextFactory 
    {
        IDbContext CreateDbContext(); 
    }
    public class DbContextFactory 
    {
        public DbContextFactory(IClientContext clientContext) 
        {
            this._clientContext = clientContext; 
        }
        private readonly IClientContext _clientContext;
        public IDbContext CreateDbContext()
        {
            // get the connectionstring from IClientContext and return the IDbContext
        } 
    }
