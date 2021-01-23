	public class BirthPlace
	{
		public String Name { get; set; }
	} 
	public class SpecialBirthPlace : BirthPlace
	{
	}
	
	public class Person 
	{
		public static readonly DateTime ImportantDate;
		public BirthPlace BirthPlace { get; set; } 
				
		public DateTime BirthDate 
		{ 
			get; private set;
		} 
		
		public void CorrectBirthDate(IRepository<SpecialBirthPlace> specialBirthPlaces, DateTime date)
		{
			if (BirthPlace != null && date < ImportantDate && specialBirthPlaces.Contains(BirthPlace)) 
			{ 
				BirthPlace = specialBirthPlaces.GetForDate(date); 
			}
		}
	} 
