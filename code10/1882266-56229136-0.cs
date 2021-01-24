    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var sourceList = new List<Foo>()
    		{new Foo()
    		{Id = 1, Date = DateTime.Now}, new Foo()
    		{Id = 2, Date = DateTime.Now.AddDays(5)}, new Foo()
    		{Id = 3, Date = DateTime.Now.AddDays(3)}, new Foo()
    		{Id = 4, Date = DateTime.Now}, new Foo()
    		{Id = 5, Date = DateTime.Now}};
    		var destinationList = new List<Foo>()
    		{new Foo()
    		{Id = 2, Date = DateTime.Now}, new Foo()
    		{Id = 3, Date = DateTime.Now}, new Foo()
    		{Id = 4, Date = DateTime.Now}, new Foo()
    		};
    		
    		Console.WriteLine("--IDs IN SOURCE LIST BUT NOT IN DESTINATION--------");
    		var resultWhereIdsExistsInSourceListButNotOnDestination = sourceList.Where(l1 => !destinationList.Any(l2 => l2.Id == l1.Id)).Select(l => l.Id).ToList();
    		resultWhereIdsExistsInSourceListButNotOnDestination.ForEach(r => Console.WriteLine(r));
    		Console.WriteLine("--IDs IN BOTH WHERE THE DATE IN SOURCE LIST IS GREATER--------");
    		var resultWhereIdsExistInBothWithDateGreaterInSourceList = sourceList.Where(l1 => destinationList.Any(l2 => l2.Id == l1.Id && l1.Date > l2.Date)).Select(l => l.Id).ToList();
    		resultWhereIdsExistInBothWithDateGreaterInSourceList.ForEach(r => Console.WriteLine(r));
    		
    		Console.WriteLine("------------------ UNINON-------------------------------------");
    		resultWhereIdsExistsInSourceListButNotOnDestination.Union(resultWhereIdsExistInBothWithDateGreaterInSourceList).ToList().ForEach(r => Console.WriteLine(r));
    		
    		
    	}
    }
    
    public class Foo
    {
    	public DateTime Date
    	{
    		get;
    		set;
    	}
    
    	public int Id
    	{
    		get;
    		set;
    	}
    }
    
    ;
