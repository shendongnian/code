    abstract class AnimalBase { public int SomeCommonProperty;}
    interface IShelterBase<out T> where T : AnimalBase
    {
        IEnumerable<T> GetAnimals();
    }
    
    class Horse : AnimalBase { }
    
    class Stable : IShelterBase<Horse>
    {
        public IEnumerable<Horse> GetAnimals()
    	{
    		return new List<Horse>();
    	}
    }
    
    class Duck : AnimalBase { }
    
    class HenHouse : IShelterBase<Duck>
    {
        public IEnumerable<Duck> GetAnimals()
    	{
    		return new List<Duck>();
    	}
    }
    void Main()
    {
        List<IShelterBase<AnimalBase>> shelters = new List<IShelterBase<AnimalBase>>();
        ///////////////////////////// following two lines do not compile
        shelters.Add(new Stable());
        shelters.Add(new HenHouse());
        /////////////////////////////
        foreach (var shelter in shelters)
        {
            var animals = shelter.GetAnimals();
            // do sth with 'animals' collection
        }
    }
