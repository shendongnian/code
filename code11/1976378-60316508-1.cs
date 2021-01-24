    Animal animal = new Dog(); //compile time type is Animal runtime type is Dog
    Console.WriteLine(animal.GetType().Name); // Dog
    ...
    animal = new Cat(); // compile time type is still Animal (c# is Type safe)
    // but runtime type just changed to Cat;
    Console.WriteLine(animal.GetType().Name); // Cat
