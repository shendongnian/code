    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Person
    {
    	public int ID;
    	public string Name;
    	public DateTime ChangeDate;
    }
    public class PersonComparer : IEqualityComparer<Person>
    {
    	public bool Equals(Person p1, Person p2)
    	{
    		return p1.ID == p2.ID;
    	}
    	public int GetHashCode(Person p)
    	{
    		return p.ID.GetHashCode();
    	}
    }
    class Program
    {
    	static void Main(string[] args)
    	{
    		var list1 = new List<Person>
    		{
    			new Person { ID = 1, Name = "Peter", ChangeDate = DateTime.Parse("2011-10-21") },
    			new Person { ID = 2, Name = "John",  ChangeDate = DateTime.Parse("2011-10-22") },
    			new Person { ID = 3, Name = "Mike",  ChangeDate = DateTime.Parse("2011-10-23") },
    			new Person { ID = 4, Name = "Dave",  ChangeDate = DateTime.Parse("2011-10-24") }
    		};
    		var list2 = new List<Person>
    		{
    			new Person { ID = 1, Name = "Pete",  ChangeDate = DateTime.Parse("2011-10-21") },
    			new Person { ID = 2, Name = "Johny", ChangeDate = DateTime.Parse("2011-10-20") },
    			new Person { ID = 3, Name = "Mikey", ChangeDate = DateTime.Parse("2011-10-24") },
    			new Person { ID = 5, Name = "Larry", ChangeDate = DateTime.Parse("2011-10-27") }
    		};
    		var pc = new PersonComparer();
    		var combined = list1.Join(list2, p => p.ID, p => p.ID, (p1,p2) => p2.ChangeDate > p1.ChangeDate ? p2 : p1)
    							.Union(list1.Except(list2, pc))
    							.Union(list2.Except(list1, pc));
    		foreach(var p in combined)
    		{
    			Console.WriteLine(p.ID + " " + p.Name + " " + p.ChangeDate);
    		}
    	}
    }
