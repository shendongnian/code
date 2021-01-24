    public class Person
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int Age { get; set; }
    }
    
    public class PersonByFirstNameComparer : IComparer<Person>
    {
    	public int Compare(Person left, Person right) => .FirstName.CompareTo(right.FirstName);
    }
    
    public class Behavior
    {
    	public virtual IComparer<Person> GetComparer() => PersonByFirstNameComparer();
    }
    
    public class PersonByLastNameComparer : IComparer<Person>
    {
    	public int Compare(Person left, Person right) => left.LastName.CompareTo(right.LastName);
    }
    
    public class SpecializedBehavior : Behavior
    {
    	public override IComparer<Person> GetComparer() => new PersonByLastNameComparer();
    }
    
    public static void Main()
    {
    	var people = new List<Person>
    	{
    		new Person{Age=10, FirstName="Pelle", LastName="Larsson"},
    		new Person{Age=90, FirstName="Nils", LastName="Nilsson"}, 
    		new Person{Age=15, FirstName="Olle", LastName="Johansson"},
    		new Person{Age=30, FirstName="Kalle", LastName="Svensson"}
    	};
    
    	var standardBehavior = new Behavior();
    	IEnumerable<Person> orderedPeople1 = 
    		people.OrderBy(p => p, standardBehavior.GetComparer());
    		
    	foreach (Person p in orderedPeople1)
    	{
    		Console.WriteLine($"{p.FirstName} {p.LastName}");
    	}
    
    	var specializedBehavior = new SpecializedBehavior();
    	IEnumerable<Person> orderedPeople2 = 
    		people.OrderBy(p => p, specializedBehavior.GetComparer());
    		
    	foreach (Person p in orderedPeople2)
    	{
    		Console.WriteLine($"{p.FirstName} {p.LastName}");
    	}
    }
