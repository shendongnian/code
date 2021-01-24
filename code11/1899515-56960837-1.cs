    public class SomeHelper : IHelper
    {
        private IRepository repo;
        public SomeHelper(IRepository repo)
        {
            this.repo = repo;
        }
        public object GetSomething()
        {
            repo.GetSomethingFromDB();
            // ... etc ...
        }
    }
