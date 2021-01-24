    public class ClientRepository : EntityBaseRepository<Client>, IClientRepository
    {
        private readonly IContextFactory<JobsLedgerApiContext> _contextFactory;
    
        public ClientRepository(IContextFactory<JobsLedgerApiContext> factory)
        {
            _contextFactory = factory;
        }
    
        // this method will set the protected Context property using the context
        // created by the factory
        public void SetContext()
        {
            Context = _contextFactory.CreateDbContext();
        }
    
        public void RelatedSuburbEntities(Suburb suburb)
        {
            Context.Entry(suburb).Reference<State>(a => a.State).Load();
        }
    }
