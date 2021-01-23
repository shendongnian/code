    interface IAnimal {}
    interface IGiraffe : IAnimal {}
    interface ITiger: IAnimal {}
    class Tiger : ITiger {}
    interface IHaveAnAnimal { IAnimal Animal { get; set; } }
    class C : IHaveAnAnimal
    {
        public IGiraffe Animal { get; set; }
    }
    ...
    IHaveAnAnimal x = new C();
    x.Animal = new Tiger(); // Uh oh. We just put a Tiger into a property of type IGiraffe.
