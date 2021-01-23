    public class MyService
    {
        private IUnitOfWorkFactory _factory;
        public MyService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }
        public MyMethod()
        {
            using(var unitOfWork1 = _factory.Create("SiteModelContainer"))
            {
                var repo1 = unitOfWork1.
                    CreateGenericRepository<SomeEntityTypeInSiteModel>();
                // Do some work
                unitOfWork1.Commit();
            }
            using(var unitOfWork2 = _factory.Create("AnotherModelContainer"))
            {
                var repo2 = unitOfWork2.
                    CreateGenericRepository<SomeEntityTypeInAnotherModel>();
                // Do some work
                unitOfWork2.Commit();
            }
        }
    }
