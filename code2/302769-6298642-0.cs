    interface IAnimal { }
    interface IShape { }
    class Tiger : IAnimal { }
    class Wolf : IAnimal { }
        
    class Circle : IShape { }
    class Rectangle : IShape { }
    public void MakeSound<T>(T animal) where T : IAnimal
    {
    }
    public void Draw<T>(T shape) where T : IShape
    {
    }
