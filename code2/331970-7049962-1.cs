    public class Person
    {
    	public string Name { get; set; }
    	
    	public override string ToString()
    	{
    		return Name ?? "";
    	}
    }
    
    public static class PersonExtensionMethod
    {
    	public static Person SingleOrDefault(this IEnumerable<Person> source)
    	{
    		var person = Enumerable.SingleOrDefault(source);
    		
    		if (person == null)
    			return new Person { Name = "Unnamed" };
    		
    		return person;
    	}
    }
    
    public static void Main()
    {
    	var emptyCollection = new Person[0];
    	var nonEmptyCollection = new Person[] { new Person { Name = "Jack" } };
    	
    	Debug.WriteLine("Empty collection: " + emptyCollection.SingleOrDefault());
    	Debug.WriteLine("Non-empty collection: " + nonEmptyCollection.SingleOrDefault());
    }
