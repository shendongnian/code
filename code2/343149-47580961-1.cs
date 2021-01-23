    using System;
    using System.Linq;
    using System.Collections.Generic;
    	
    class Person
    { 
        public int PersonId; 
        public string car  ; 
    }
    
    class Result
    { 
       public int PersonId;
       public List<string> Cars; 
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		List<Person> persons = new List<Person>()
    		{
    			new Person { PersonId = 1, car = "Ferrari" },
    			new Person { PersonId = 1, car = "BMW" },
    			new Person { PersonId = 2, car = "Audi"}
    		};
    		
    		//With Query Syntax
    		
    		List<Result> results1 = (
    			from p in persons
    			group p by p.PersonId into g
    			select new Result()
    				{
    					PersonId = g.Key, 
    					Cars = g.Select(c => c.car).ToList()
    				}
    			).ToList();
    		
    		foreach (Result item in results1)
    		{
    			Console.WriteLine(item.PersonId);
    			foreach(string car in item.Cars)
    			{
    				Console.WriteLine(car);
    			}
    		}
    		
    		Console.WriteLine("-----------");
    		
    		//Method Syntax
    		
    		List<Result> results2 = persons
    			.GroupBy(p => p.PersonId, 
    					 (k, c) => new Result()
    							 {
    								 PersonId = k,
    								 Cars = c.Select(cs => cs.car).ToList()
    							 }
    					).ToList();
    				
    		foreach (Result item in results2)
    		{
    			Console.WriteLine(item.PersonId);
    			foreach(string car in item.Cars)
    			{
    				Console.WriteLine(car);
    			}
    		}
    	}
    }
