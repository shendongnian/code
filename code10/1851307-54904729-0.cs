    public interface Room<TThingCollection<TThing>> 
        where TThingCollection : ThingCollection<TThing> 
        where TThing : IThing
    { }
    
    public interface SpecialRoom<TThingCollection<TThing>> : Room<TThingCollection> 
        where TThingCollection : SpecialThingCollection<TThing> 
        where TThing : ISpecialThing
    { }
