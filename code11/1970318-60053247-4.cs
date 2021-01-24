    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
    
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
