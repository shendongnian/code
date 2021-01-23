    abstract interface MyCollection<out T> {
      public List<T> Items { get; set; }
    }
    class Animal {}
    class AnimalCollection : MYCollection<Animal> 
    { 
        public List<Animal> {get; set; }
    }
    class Giraffe : Animal {}
    class GiraffeCollection : MyCollection<Giraffe> 
    {
        public List<Giraffe> { get; set; } 
    }
    static class X 
    {
      public MyCollection<Animal> GetThing(bool f) {
        return f ? new GiraffeCollection() : new AnimalCollection();
      }
    }
    class Tiger : Animal {}
    ...
    MyCollection<Animal> animals = X.GetThing(true); // returns a GiraffeCollection
    animals.Items = new List<Animal>() { new Tiger(); }
