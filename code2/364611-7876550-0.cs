    public abstract class AnimalInfo<T> where T: Animal
    {
        public abstract String Sound { get; }
        public abstract T CreateAnimal();
    }
