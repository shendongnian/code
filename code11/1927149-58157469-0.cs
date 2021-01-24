    class BloodType
    {
    	public BloodType()//default constructor
    	{
    		
    	}
    
    	public BloodType(string name)//constructor
    	{
    		this.name = name;
    	}
    
    	public string name { get; set; }
    
    	public static List<BloodType> GetTrueBloodType(BloodType first, Dictionary<BloodType, List<BloodType>> dic)
    	{
    		return dic[first];
    	}
    }
