    public class RavenSessionProvider : Provider<IDocumentSession>
    {
        private readonly IDocumentStore _documentStore;
    
        public RavenSessionFactory(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
    
        public IDocumentSession GetInstance(IContext ctx)
        {
            Debug.Write("IDocumentSession Created");
            return _documentStore.OpenSession();
        }
    }
