    // Suppose this declaration were legal:
    interface IMyCollection<out T> 
    {
      List<T> Items { get; set; } 
    }
    class Animal {}
    class AnimalCollection : IMyCollection<Animal> 
    { 
      public List<Animal> { get; set; }
    }
    class Giraffe : Animal {}
    class GiraffeCollection : IMyCollection<Giraffe> 
    {
      public List<Giraffe> { get; set; } 
    }
    static class X 
    {
      public IMyCollection<Animal> GetThing() 
      {
        // IMyCollection is covariant in T, so this is legal.
        return new GiraffeCollection(); 
      }
    }
    class Tiger : Animal {}
    ...
    IMyCollection<Animal> animals = X.GetThing(); 
    // GetThing() actually returns a GiraffeCollection
    animals.Items = new List<Animal>() { new Tiger(); }
