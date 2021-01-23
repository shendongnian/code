    public interface IThing
    {
      int X { get; }
    }
    
    public class Thing : IThing
    {
      int X { get; set; }
    }
    
    class Pack
    {
        private readonly List<IThing> myThings = new List<IThing>();
        private const int MaxValue = 5;
    
        public void Add(IThing thing)
        {
            if (myThings.Sum(t => t.X) + thing.X > MaxValue)
                throw new Exception("this thing doesn't fit here");
            myThings.Add(new InnerThing(thing));
        }
    
        public int Count
        {
            get { return myThings.Count; }
        }
    
        public IThing this[int index]
        {
            get { return myThings[index]; }
        }
    	
    	private class InnerThing : IThing
        {
    	  public InnerThing(IThing thing)
    	  {
    	    X = thing.X;
    	  }
          int X { get; private set; }
        }
    }
