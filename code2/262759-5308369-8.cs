    Animal animal;
    Dog dog;
    animal = Human.CreateHuman(); // sets the VTable field to HumanVTable
    animal.VTable.AnimalEat(animal); // calls HumanVTable.AnimalEat
    animal = Animal.CreateAnimal(); // sets the VTable field to AnimalVTable
    animal.VTable.AnimalEat(animal); // calls AnimalVTable.AnimalEat
    dog = Dog.CreateDog(); // sets the VTable field to AnimalVTable
    Dog.DogEat(dog); // calls DogEat, obviously
    animal = dog;
    animal.VTable.AnimalEat(); // calls AnimalVTable.AnimalEat
