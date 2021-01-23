    interface IAnimal {}
    interface IGiraffe : IAnimal {}
    interface ITiger: IAnimal {}
    class Tiger : ITiger {}
    interface IHaveAnAnimal { IAnimal Animal { get; } }
    class C : IHaveAnAnimal
    {
        public IGiraffe Animal { get; }
    }
