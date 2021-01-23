    class Shark : Animal {} // some other config action
    ...
    var cages = new List<Cage<Animal>>();    
    cages.Add(new TigerCage()); 
    Cage<Animal> firstCage = cages[0]; 
    firstCage.InsertIntoCage(new Shark());
