    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Animal> animals = new List<Animal> { new Cat(), new Cat(), new Dog(), new Cat(), new Dog() };
    
                var dogs = animals.OfType<Dog>().ToList();
                dogs.ForEach(dog => dog.Bark());
    
                var cats = animals.OfType<Cat>().ToList();
                cats.ForEach(cat => cat.Meow());
    
                var actualTypes = animals.Select(animal => animal.GetType()).ToList();
            }
    
            abstract class Animal { }
    
            class Dog : Animal { public void Bark() { } }
    
            class Cat : Animal { public void Meow() { } }
        }
    }
