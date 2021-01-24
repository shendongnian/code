    Animal dog = new Dog(); //compile time type is Animal runtime type is Dog
    Console.WriteLine(dog.GetType().Name); // Dog
    ...
    dog = new Cat(); // compile time type is still Animal (c# is Type safe)
    // but runtime type just changed to Cat;
    Console.WriteLine(dog.GetType().Name); // Cat
