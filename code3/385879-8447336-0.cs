    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
    
    public class MyEfContext : DbContext, IUnitOfWork
    {
        // your custom context code
    }
