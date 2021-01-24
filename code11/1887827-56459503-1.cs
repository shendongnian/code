    // Animal in the most general: all we can do is to count its legs
    public interface IAnimal { 
        // get: I doubt if we should maim animals; let number of legs be immutable
        int NumberOfLegs { get; } 
    }
    
    // Baby animal is animal and it can grow into adult one
    public interface IBabyAnimal : IAnimal { 
        IAdultAnimal WillGrowToBe()
    }
    
    // Adult animal can give birth baby animal
    public interface IAdultAnimal : IAnimal { 
        IAnimal Baby();
    }
    
    // Dog is adult animal, it can birth pups
    public class Dog : IAdultAnimal {
        public Dog() 
    
        public int NumberOfLegs { get; } => 4;
    
        public Baby() => new Pup();
    }
    
    // Pup is baby animal which will be dog when grow up
    public class Pup : IBabyAnimal {
        public Pup() 
    
        public int NumberOfLegs { get; } => 4;
    
        public WillGrowToBe() => new Dog();
    }
