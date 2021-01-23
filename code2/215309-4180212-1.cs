    public sealed class Auditor<T> : IRepository<T>
    {
        private readonly IRepository<T> _repository;
        public Auditor(IRepository<T> repository)
        {
            _repository = repository;    
        }
        public void Create(T entity)
        {
            //Auditing here...
            _repository.Create(entity);
        }
        //And so on for other methods...
    }
