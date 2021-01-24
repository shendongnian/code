    public class Person
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int Age { get; set; }
    }
    
    public class PersonByFirstNameComparer : IComparer<Person>
    {
    	public int Compare(Person left, Person right) =>
            left.FirstName.CompareTo(right.FirstName);
    }
    
    public class Behavior
    {
    	public virtual IComparer<Person> GetComparer() => PersonByFirstNameComparer();
    }
    
    public class PersonByLastNameComparer : IComparer<Person>
    {
    	public int Compare(Person left, Person right) =>
            left.LastName.CompareTo(right.LastName);
    }
    
    public class SpecializedBehavior : Behavior
    {
    	public override IComparer<Person> GetComparer() => new PersonByLastNameComparer();
    }
