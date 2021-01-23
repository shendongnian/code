	public class BirthPlace
	{
		public BirthPlace(String name, Boolean isSpecial = false)
		{
			Name = name;
			IsSpecial = isSpecial
		} 
		
		public String Name { get; private set; }
		public Boolean IsSpecial { get; private set; }
	}
	
	public class Person 
	{
		public static readonly DateTime ImportantDate;
		public BirthPlace BirthPlace { get; set; } 
				
		public DateTime BirthDate 
		{ 
			get; private set;
		} 
		
		public void CorrectBirthDate(IRepository<BirthPlace> birthPlaces, DateTime date)
		{
			if (BirthPlace != null && date < ImportantDate && BirthPlace.IsSpecial) 
			{ 
				BirthPlace = specialBirthPlaces.GetForDate(date); 
			}
		}
	} 
