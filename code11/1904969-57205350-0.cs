        public class Repository : IRepository
        {
            public int GetInt()
            {
                return 999;
            }
        }
        public class Service : IService
        {
            IRepository Repository;
            public Service(IRepository repository)
            {
                this.Repository = repository;
            }
            public string GetStringFromInt()
            {
                return Repository.GetInt().ToString();
            }
        }
