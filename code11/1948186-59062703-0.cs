    public class RootObject
    {
    	[JsonProperty("object")]
    	public WeighMix Object{get;set;}
    }
    
    // Define other methods and classes here
    public class WeighMix
        {
            public double Weigh { get; set; }
    
            public WeighMix()
            {
            }
    
            public WeighMix(double weigh)
            {
                Weigh = weigh;
            }
        }
