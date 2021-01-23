    public class Animal {   }
    
    public class Dog : Animal {   }
    
    List<Dog> dogs = new List<Dog>();
    List<Animal> animals = dogs.Cast<Animal>().ToList();
