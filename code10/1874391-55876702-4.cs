    public class EntityRepository : EntityBaseRepository<User>, IEntityRepository
    {
        private IContextFactory<JobsLedgerAPIContext> _factory;
    
        //assuming IEntityRepsitory has the method defined below
        public void SetDbContext(string connectionString)
        {
            // set the base context
            Context = _factory.CreateDbContext(connectionString);
        }
    
        public EntityRepository(IContextFactory<JobsLedgerAPIContext> factory)
        {
            _factory = factory;  
        }
    }
