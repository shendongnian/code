    public enum Gender
    {
    	Male = 1,
    	Female = 2
    }
    
    class PatientNumberGenerator
    {
    	private static Random _random = new Random();
    
    	public string GetCurrentDate()
    	{
    		return DateTime.Today.ToShortDateString();
    	}
    
    	public int RadomNum()
    	{
    		return _random.Next(0, 1000);
    	}
    
    	public string GeneratePatientNumber(Gender gender)
    	{
    		return GetCurrentDate() + "-" + (int)gender + "-" + RadomNum();
    	}
    }
