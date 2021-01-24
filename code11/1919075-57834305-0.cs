    using System;
    
    namespace ConsoleApp30
    {
        public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
        {
    
        }
    
        public interface IRepository<TEntity> : IRepository where TEntity : class
        {
        }
    
        public interface IRepository
        {
        }
    
        public interface ITransaction
        {
        }
    
        public interface ITransactionProvider
        {
        }
    
        public class TransactionProvider : ITransactionProvider
        {
            public void AddPending(ITransaction transaction)
            {
                // Get the targeted types
                var typeEntity = typeof(string);
                var typePendingEntity = typeof(string);
    
                // Get the Repository Instances for each type
                var repositoryEntity = GetRepositoryInstance(typeEntity);
                var repositoryPendingEntity = GetRepositoryInstance(typePendingEntity);
            }
    
            // -----
            // HERE...I want to return the generated type as its' IRepository<>...how?
            // -----
            private IRepository GetRepositoryInstance(Type entity)
            {
                var repositoryType = typeof(GenericRepository<>).MakeGenericType(entity);
                var repository = Activator.CreateInstance(repositoryType);
    
                return (IRepository)repository;
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                var tp = new TransactionProvider();
                tp.AddPending(null);
    
                Console.WriteLine("Hello World!");
            }
        }
    }
