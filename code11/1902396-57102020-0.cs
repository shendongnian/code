    public class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int Age { get; set; }
    }
    
    public class PersonAgeOrderSpecification : OrderSpecification<Person, int>
    {
    	public PersonAgeOrderSpecification(Sort direction) : base(direction) { }
    	public override Expression<Func<Person, int>> AsExpression()
    	{
    		return person => person.Age;
    	}
    }
