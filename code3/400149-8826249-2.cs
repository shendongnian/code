    public enum PatientGender
	{
	    Male = 1,
	    Female
	}
	
	public int RandomNum()
	{
	    return new Random().Next(0, 1000);
	}
    var patientNumber = string.Format("{0}-{1}-{2}",
                                      DateTime.UtcNow.ToString("yyyy-MM-dd"),
                                      (int)PatientGender.Male,
                                      RandomNum());
