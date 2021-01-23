    class Animal {}
    class Reptile : Animal {}
    class Snake : Reptile {}
    class Mammal : Animal {}
    class Tiger : Mammal {}
    class Giraffe : Mammal {}
    delegate void D(Mammal m);
    static void DoAnimal(Animal a) {}
    static void DoMammal(Mammal m) {}
    static void DoTiger(Tiger t) {}
    D dm = DoMammal;
    dm(new Tiger());
