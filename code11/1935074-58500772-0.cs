    void Main()
    {
    	SpecializedBehavior behavior = new SpecializedBehavior();
    	IEnumerable<Person> orderedResult = behavior.Sort(persons);
    }
    
    public class Person
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int Age { get; set; }
    }
    
    public class Behavior
    {
    	public virtual IEnumerable<Person> Sort(IEnumerable<Person> persons)
    	{
    		return persons.OrderBy(p => p.FirstName);
    	}
    }
    
    public class SpecializedBehavior : Behavior
    {
    	public override IEnumerable<Person> Sort(IEnumerable<Person> persons)
    	{
    		return persons.OrderBy(p => p.Age);
    	}
    }
    
    
    List<Person> persons = new List<Person>
    {
    	new Person{Age=10, FirstName="Pelle", LastName="Larsson"},
    	new Person{Age=90, FirstName="Nils", LastName="Nilsson"},
    	new Person{Age=15, FirstName="Olle", LastName="Johansson"},
    	new Person{Age=30, FirstName="Kalle", LastName="Svensson"}
    };
