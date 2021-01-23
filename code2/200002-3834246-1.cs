    CircleFactory: IDrawFactory
    {
      string Key { get; }
      IDraw Create();
    }
    
    TriangleFactory: IDrawFactory
    {
      string Key { get; }
      IDraw Create();
    }
    
    DrawFactory
    {
       List<IDrawFactory> Factories { get; }
       IDraw Create(string key)
       {
          var factory = Factories.FirstOrDefault(f=>f.Key.Equals(key));
          if (factory == null)
              throw new ArgumentException();
          return factory.Create();
       }
    }
    
    void Main()
    {
        DrawFactory factory = new DrawFactory();
        factory.Create("circle");
    }
