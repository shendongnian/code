    public class DogInfo : AnimalInfo<Dog>
    {
        public override string Sound
        {
            get { return "Bark"; }
        }
        public override Dog CreateAnimal()
        {
            return new Dog(this);
        }
    }
