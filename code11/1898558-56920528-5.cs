    class Person
    {
        public string Name { get; set; }
    
        public int Priority { get; set; }
    
        public string[] Nicknames { get; set; }
    }
    
    class PersonEqualityComparer : IEqualityComparer<Person>
    {
    	public bool Equals(Person x, Person y)
    	{
    		if (x == null || y == null) return false;
    
    		return x.Nicknames.Any(i => y.Nicknames.Any(j => i == j));
    	}
    
    	// This is bad for performance, but if performance is not a
    	// concern, it allows for more readability of the LINQ below
    	// However you should check the Edit, if you want a truely 
    	// LINQ only solution, without a wonky implementation of GetHashCode
    	public int GetHashCode(Person obj) => 0;
    }
    // ...
    
    var people = new List<Person>
    {
        new Person { Name = "Steve", Priority = 4, Nicknames = new[] { "Stevo", "Lefty", "Slim" } },
        new Person { Name = "Karen", Priority = 6, Nicknames = new[] { "Kary", "Birdie", "Snookie" } },
        new Person { Name = "Molly", Priority = 3, Nicknames = new[] { "Mol", "Lefty", "Dixie" } },
        new Person { Name = "Greg", Priority = 5, Nicknames = new[] { "G-man", "Chubs", "Skippy" } }
    };
    
    var distinctPeople = people.OrderBy(i => i.Priority).Distinct(new PersonEqualityComparer());
