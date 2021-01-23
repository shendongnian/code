    class PatientNumber
    {
    	public enum Gender
    	{
    		MalePatient = 1,
    		FemalePatient = 2
    	}
    
    	Random _random = new Random();
    
    	public string GetCurrentDate()
    	{
    		return DateTime.Today.ToShortDateString();
    	}
    
    	public int RadomNum()
    	{
    		return _random.Next(0, 1000);
    	}
    
    	public string GeneratePatientNumber(Gender gender)	{
    		return GetCurrentDate() + "-" + (int)gender + "-" + RadomNum();
    	}
    }
