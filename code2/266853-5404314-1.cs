    public class MyService 
    {
        public MyService(IFactory<IRepository> repositoryFactory)
        {
            var repository = repositoryFactory.CreateNew();
        }
    }
