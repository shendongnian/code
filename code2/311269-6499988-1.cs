	public class Person
	{
		public string FirstName {get; set;}
		public string LastName  {get; set;}
	}
	var people = new [] {
		new Person { FirstName = "Amy", LastName = "Apple" },
		new Person { FirstName = "Andy", LastName = "Apple" },
		new Person { FirstName = "Charlie", LastName = "Coconut" } 
	};
	var sortedPeople = people
		.OrderBy(f => f.LastName)
		.ThenByDescending(f => f.FirstName);
