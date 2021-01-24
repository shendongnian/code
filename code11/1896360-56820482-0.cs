    enum PlaceType
    {
    	Toilet,
    	Restaurant
    }
    
    class Place
    {
    	public Place(PlaceType type)
    	{
    		Type = type;
    	}
    
    	public PlaceType Type { get; }
    }
    
    class Toilet : Place
    {
    	public Toilet() : base(PlaceType.Toilet)
    	{
    
    	}
    }
