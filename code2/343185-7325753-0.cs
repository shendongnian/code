    public interface Animal 
    {
      string Name { get; }
    }
    
    public class Dog : Animal
    {
      public string Name { get { return "Dog"; } }
    }
    
    public class Cat : Animal
    {
      public string Name { get { return "Cat"; } }
    }
    
    public class Test 
    {
      static void Main()
      {
          // Polymorphism
          Animal animal = new Dog();
    
          Animal animalTwo = new Cat();
          Console.WriteLine(animal.Name);
          Console.WriteLine(animalTwo.Name);
      }
    }
