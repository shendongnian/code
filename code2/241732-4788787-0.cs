    interface IAnimal { }
    class Lion : IAnimal { public void Roar() {} }
    class Giraffe: IAnimal { }
    delegate void D(IAnimal animal);
    static void M(Lion lion) { lion.Roar(); }
