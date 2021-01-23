    public class TestAnimals
    {
        protected static void DoMove<T>(T animal) where T : IAnimal
        {
            animal.Move();
        }    
        public void RunTest()
        {
            List<IAnimal> animals = new List<IAnimal>
            {
                new Duck(),
                new Fish(),
                new Ant()
            };    
            foreach (var animal in animals)
            {
                DoMove(animal);
            }
        }
    }
    
