    public class Animal {
        public bool HasHair { get { return true; } }
        public int Legs { get { return 4; } }
        public virtual string Speaks { get { return "Does a sound"; } }        
    }
    // We can now inherit from Animal to write our Cat and Dog classes.
    public class Cat : Animal {
        public overrides string Speaks { get { return "Meows"; } }
    }
    public class Dog : Animal { 
        public overrides string Speaks { get { return "Barkles"; } }
    }
