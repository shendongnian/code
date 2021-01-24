    public abstract class Pet
    {
        protected string name;
        protected string species;
        public abstract void Speak();
        public abstract void Play();
        public abstract void Info();
    }
    class Dog : Pet
    {
        public Dog(string xname, string xspecies)
        {
            name = xname;
            species = xspecies;
        }
        // Implementation of Pet here
    }
