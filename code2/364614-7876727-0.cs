    public static class AnimalFactory
    {
        public static Animal CreateAnimal(Type animalType)
        {
            return Activator.CreateInstance(animalType) as Animal;
        }
        public static Animal CreateAnimal(string animalType)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(animalType);
            return Activator.CreateInstance(type) as Animal;
        }
       
    }
