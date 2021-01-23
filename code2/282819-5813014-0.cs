    abstract class Organism
    {
        public abstract int NumberOfLegs();
    }
    abstract class Biped : Organism
    {
        public sealed override int NumberOfLegs()
        {
            return 2;
        }
    }
    
    abstract class Quadroped : Organism
    {
        public sealed override int NumberOfLegs()
        {
            return 4;
        }
    }
    class Humand : Biped
    {
    }
    class Dog : Quadroped
    {
    }
