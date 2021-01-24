    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var bob = new Director("Bob");
    		Console.WriteLine(bob.Salary);
    		
    	}
    }
    
    public class Employee
    {
    	public string Name {get;set;}
    	public float Salary {get;set;}
    	
    	public Employee(string name, float salary)
    	{
    		Name = name;
    		Salary = salary;
    	}
    }
    
    public class Director : Employee
    {
    	public Director(string name) : base (name, 250000)
    	{
    		
    	}
    }
