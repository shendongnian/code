    public class Animal
        {
                 //some codes...
        }
  
   
    public class Merge
        {
           public Merge()
            {
               AnimalFirst=new Animal();
            }
            public AnimalFirst { get; set; }
            public IEnumerable<Animal> All { get; set; }
        }
         List<Merge> merges = new List<Merge>();
         var animals = merges.AnimalFirst ;
         var All =merges.All;
