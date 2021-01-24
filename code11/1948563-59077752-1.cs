    public abstract class Animal
    {
      public abstract void makeSound()
      {
        Console.WriteLine("[nothing happens]");
      }
    }
    public class Cat : Animal
    {
      public override void makeSound()
      {
        Console.WriteLine("Meow");
      }
    }
    public class Dog : Animal
    {
      public override void makeSound()
      {
        Console.WriteLine("Woof");
      }
    }
    public static void main(String[] args) 
    {
        var animals = new List<Animal>();
        animals.Add(new Dog());
        animals.Add(new Cat());
        Console.Add(animals[0].MakeSound());  // Woof
        Console.Add(animals[1].MakeSound());  // Meow
    }
