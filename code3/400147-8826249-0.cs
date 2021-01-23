    public enum PatientGender
	{
	    Male = 1,
	    Female
	}
	
	public Int32 RandomNum()
	{
	    return new Random().Next(0, 1000);
	}
    var patientNumber = string.Format("{0}-{1}-{2}",
                                      DateTime.UtcNow.ToShortDateString(),
                                      (int)PatientGender.Male,
                                      RandomNum());
