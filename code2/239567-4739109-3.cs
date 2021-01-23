        public class Program
        {
            public void ConsumeRepository(string connectionString)
            {
                IRead reader = null;
                IRepository repository = null;
                if (RepositoryFactory.ConnectionStringIsReadOnly(connectionString))
                    reader = RepositoryFactory.GetReadOnlyRepository(connectionString);
                else
                {
                    repository = RepositoryFactory.GetRepository(connectionString);
                    reader = repository;
                }
                object o = reader.Read();
                // do something with o
                // if allowed then write o to repository
                if (repository != null)
                {
                    repository.Write(o);
                }
            }
        }
