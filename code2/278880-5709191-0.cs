    abstract class Enclosure
    {
        public abstract Animal Contents();
    }
    class Aquarium : Enclosure
    {
        public override Fish Contents() { ... }
    }
    
