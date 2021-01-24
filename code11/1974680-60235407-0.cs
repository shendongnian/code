    public interface IUnitOfWork : IDisposable {
    
        //. . .
    
        Task<bool> SaveAsync();
    }
