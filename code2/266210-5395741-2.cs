    public class AnimalShowTimeService : IAnimalShowTimeService
    {
        readonly IShowTimeUpdatedVisitor showTimeUpdatedVisitor;
        public AnimalShowTimeService(
                IShowTimeUpdatedVisitor showTimeUpdatedVisitor)
        {
            this.showTimeUpdatedVisitor = showTimeUpdatedVisitor;
        }
        public void IncreaseShowTimeForAnimal(IAnimal animal)
        {
            animal.ShowTimeUpdated(showTimeUpdatedVisitor);
        }
    }
