    public class Zoo
    {
         public List<Animal> items;
         protected BaseClass()
         {         // some code to build list of items     }
     }
    
    public class PettingZoo : Zoo
    {
         public PettingZoo : base() {}
    }
    
    public class CatComplex : Zoo
    {
         public CatComplex : base() {}
    }
    
    public class Animal {}
    public class Sheep : Animal {}
    public class Tiger : Animal {}
...
    PettingZoo myZoo = new PettingZoo();
    myZoo.items.Add(new Tiger());
