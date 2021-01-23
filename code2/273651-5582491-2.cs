    interface IMyCollection<out T> 
    {
      public IEnumerable<T> Items { get; }
    }
    class Animal {}
    class AnimalCollection : IMyCollection<Animal> 
    { 
      public IEnumerable<Animal> { get { yield return new Tiger(); } }
    }
    class Giraffe : Animal {}
    class GiraffeCollection : IMyCollection<Giraffe> 
    {
      public IEnumerable<Giraffe> { get { yield return new Giraffe(); } } 
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
    MyCollection<Animal> animals = X.GetThing(true); 
    // GetThing(true) returns a GiraffeCollection
    foreach(Animal animal in animals.Items) { ... } 
    // Items yields a giraffe, which is an animal
