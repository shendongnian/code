    interface IMyCollection<out T> 
    {
      public List<T> Items { get; set; }
    }
    class Animal {}
    class AnimalCollection : IMyCollection<Animal> 
    { 
      public List<Animal> {get; set; }
    }
    class Giraffe : Animal {}
    class GiraffeCollection : IMyCollection<Giraffe> 
    {
      public List<Giraffe> { get; set; } 
    }
    static class X 
    {
      public IMyCollection<Animal> GetThing(bool f) 
      {
        return f ? (IMyCollection<Animal>)new GiraffeCollection() 
                 : (IMyCollection<Animal>)new AnimalCollection();
      }
    }
    class Tiger : Animal {}
    ...
    IMyCollection<Animal> animals = X.GetThing(true); 
    // GetThing(true) returns a GiraffeCollection
    animals.Items = new List<Animal>() { new Tiger(); }
