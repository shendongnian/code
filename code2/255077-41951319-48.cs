    var mixedAnimals = new Animal[] // i.e. Polymorphic collection
    {
        new Zebra("Zed"),
        new Elephant("Ellie")
    };
    foreach (dynamic animal in mixedAnimals)
    {
        castedAnimals.Add(animal);
    }
    // Returns Zed, Ellie
