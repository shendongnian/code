    class Animal
    {
         public virtual string MakeNoise() { }
    }
    
    class Dog : Animal 
    {
         public override string MakeNoise() { return "Hof! Hof! Hof!" }
    }
    //
    Animal dog = new Dog();
    var noise = dog.MakeNoise();
