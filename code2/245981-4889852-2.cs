    class C : IHaveAnAnimal
    {
        IAnimal IHaveAnAnimal.Animal { get { return this.Animal; } }
        public IGiraffe Animal { get; }
    }
