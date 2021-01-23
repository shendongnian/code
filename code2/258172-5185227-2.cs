    public class MyRepository : IMyRepository
    {
        private readonly IContextFactory _contextFactory;
        public MyRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public GetObjects()
        {
            using(var context = _contextFactory.Get())
            {
            }
        }
    }
