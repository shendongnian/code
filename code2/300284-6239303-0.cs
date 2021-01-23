    public class AnimalsService : IAnimalsService
    {
        private readonly IRepository<Animal> _repository;
        public AnimalsService(IRepository<Animal> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Animal> GetFiveLeggedAnimals()
        {
         // animal specific business logic
        }
    }
