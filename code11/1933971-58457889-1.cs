    public class TimeMulti : ITimeMulti
    {
    	public DateTime DateTimeUtc { get; set; }
    
    	public float Source { get; set; }
      
    	// Using Dictionary will be much faster than Reflection 
    	protected static Dictionary<string, float> Multipliers { get; set; }
    
    	// Number of Properties (the set should be within the derived classes)
    	public int MultCount { get; protected set; }
    
    
    	// This is a restriction to create this instance from the derived classes only 
    	private TimeMulti() { }	
    	
    	// for derived classes 
    	protected TimeMulti(int multCount)
    	{
    		// Should be in this constructor only
    		Initiate(multCount);
    	}
    
    	// This is the main method to generate the multiplication part. 
    	public void Generate(int multNumber, int multiplier)
    	{
            if (multNumber == 0)
            {
                Multipliers["Mult"] = Source * multiplier;
            }
            else if (Multipliers.ContainsKey("Mult" + multNumber))
            {
                // store the value in the dictionary (this is for reference)
                Multipliers["Mult" + multNumber] = SetMult(multNumber, Source * multiplier);
            }
            else
            {
                throw new NullReferenceException();
            }
    
    	}
    	
    	// On new instance, this will fired, which will setup the dictionary
    	protected void Initiate(int numberOfMultipliers)
    	{
			// Ensure you have an active instance of the dictionary
            if (Multipliers == null)
                Multipliers = new Dictionary<string, float>();
           
			// Ensurance 
            if(numberOfMultipliers > 0)
            {
                MultCount = numberOfMultipliers;
                for (int x = 1; x <= numberOfMultipliers; x++)
                    if (!Multipliers.ContainsKey("Mult" + x))
                        Multipliers.Add("Mult" + x, 0);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
    
    	}
    	
    	// this is where we will replace Reflection, here is just returning the multValue
    	// we will override it on the derived classes 
    	protected virtual float SetMult(int MultNumber, float multValue) => multValue;
    
    }
