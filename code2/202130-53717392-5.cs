	public class Ape : IAnimal 
    {
        public string Name => "Ape";
        public AnimalType AnimalType => AnimalType.Ape;
	}
	
	
	public class Dog : IAnimal 
    {
        public string Name => "Dog";
        public AnimalType AnimalType => AnimalType.Dog;
	}
	
	public class Cat : IAnimal
    {
        public string Name => "Cat";
        public AnimalType AnimalType => AnimalType.Cat;
	}
	
	public interface IAnimal 
    {
         string Name {get;}
         AnimalType AnimalType {get;}
	}
