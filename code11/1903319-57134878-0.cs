    public class Person
    {
    	[ColumnOrder(Order = 1)]
    	public int Id { get; set; }
    	[ColumnOrder(Order = 25)]
    	public string Name { get; set; }
    	[ColumnOrder(Order = 3)]
    	public int Age { get; set; }
    }
    
    public class Employee : Person
    {
    	[ColumnOrder(Order = 10)]
    	public double Salary { get; set; }
    }
