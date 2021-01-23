    void Main()
    {
    	var fieldName = "LastName";
    	var value = "test";
    	
    	var db = new List<Person>() {
    		new Person() { name = "fred jones", sex = "male", age = 55 },
    		new Person() { name = "samantha jones", sex = "female", age = 45 },
    		new Person() { name = "cindy jones", sex = "female", age = 6 }
    	};
    	
    	db.Where( Person.GetFilter("sex", "==", "female").Compile() ).Dump();
    }
    class Person
    {
    	public string name;
    	public string sex;
    	public int age;
    
    	public static Expression<Func<Person,bool>> GetFilter<T>(string column, string @operator, T value)
    	{
    		var ops = new Dictionary<string, Func<Expression, Expression, Expression>>() {
    			{ "==", (x,y) => Expression.Equal(x,y) },
    			{ "<=", (x,y) => Expression.LessThanOrEqual(x,y) },
    			{ ">=", (x,y) => Expression.GreaterThanOrEqual(x,y) },
    			{ ">", (x,y) => Expression.GreaterThan(x,y) },
    			{ "<", (x,y) => Expression.LessThan(x,y) },
    		};
    			
    		var param = Expression.Parameter(typeof(Person));
    		var deref = Expression.PropertyOrField(param, column);
    		var testval = Expression.Constant(value);
    
    		return Expression.Lambda<Func<Person,bool>>(
    			ops[@operator](deref, testval),
    			param);
    	}
    }
