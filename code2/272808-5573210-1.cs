    public class DocumentStoreProvider : Provider<IDocumentStore>
    {
        public IDocumentStore GetInstance(IContext ctx)
        {
            var store = new DocumentStore 
                       { Url = System.Web.Configuration.WebConfigurationManager.AppSettings["Raven.DocumentStore"]});
            store.Initialize();
            return store;
        }
    }
