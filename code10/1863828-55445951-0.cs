    public class RepositoryWrapper : IRepositoryWrapper
    {
            private readonly ModelContext _modelContext;
           
            public RepositoryWrapper(ModelContext modelContext)
            {
            _modelContext= modelContext;
            }
    }
