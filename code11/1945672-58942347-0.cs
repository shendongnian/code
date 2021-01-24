using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class Program
{
	
	
	public static void Main()
	{
		
		var things = GetThings();
		var ageRanges = new Dictionary<AgeRange, int> {
			{new AgeRange(0, 4), 0},
			{new AgeRange(5, 9), 0},
			{new AgeRange(10, 14), 0},
			{new AgeRange(15, 19), 0},
			{new AgeRange(20, 24), 0},
			{new AgeRange(25, 29), 0},
			{new AgeRange(30, 34), 0},
			{new AgeRange(35, 39), 0}
		};
		var thingsByAge = ageRanges.Select(r => new KeyValuePair<AgeRange, int>(r.Key, things.Count(t => r.Key.Lower <= (DateTime.Now.Year - t.YearBuilt) && (DateTime.Now.Year - t.YearBuilt) <= r.Key.Upper))).ToList();
		
		var json = Newtonsoft.Json.JsonConvert.SerializeObject(thingsByAge, Newtonsoft.Json.Formatting.Indented);
		//var json = Newtonsoft.Json.JsonConvert.SerializeObject(stackFlowAnswer, Newtonsoft.Json.Formatting.Indented);
		Console.WriteLine(json);
		
	}
	
	public static List<Thing> GetThings()
	{
		 var things = new List<Thing>();
			things.AddRange(MakeThings(2, 2019)); things.AddRange(MakeThings(12, 2018)); things.AddRange(MakeThings(2, 2017)); things.AddRange(MakeThings(0, 2016)); things.AddRange(MakeThings(0, 2016));
			things.AddRange(MakeThings(7, 2015)); things.AddRange(MakeThings(8, 2014)); things.AddRange(MakeThings(15, 2013)); things.AddRange(MakeThings(5, 2012)); things.AddRange(MakeThings(5, 2011));
			things.AddRange(MakeThings(0, 2010)); things.AddRange(MakeThings(0, 2009)); things.AddRange(MakeThings(0, 2008)); things.AddRange(MakeThings(0, 2007)); things.AddRange(MakeThings(0, 2006));
			things.AddRange(MakeThings(9, 2005)); things.AddRange(MakeThings(4, 2004)); things.AddRange(MakeThings(5, 2003)); things.AddRange(MakeThings(5, 2002)); things.AddRange(MakeThings(5, 2001));
			things.AddRange(MakeThings(1, 2000)); things.AddRange(MakeThings(5, 1999)); things.AddRange(MakeThings(5, 1998)); things.AddRange(MakeThings(5, 1997)); things.AddRange(MakeThings(5, 1996));
			things.AddRange(MakeThings(1, 1995));
			things.AddRange(MakeThings(1, 1990));
			things.AddRange(MakeThings(1, 1985));
			things.AddRange(MakeThings(1, 1980));
			things.AddRange(MakeThings(1, 1975));
			things.AddRange(MakeThings(1, 1970));
			things.AddRange(MakeThings(1, 1965));
			things.AddRange(MakeThings(1, 1960));
			things.AddRange(MakeThings(1, 1955));
			things.AddRange(MakeThings(1, 1950));
			things.AddRange(MakeThings(1, 1945));
		
		return things;
	}
	
	public static List<Thing> MakeThings(int count, int year)
	{
		var ret = new List<Thing>();
		for(var i = 0; i < count; i++)
		{
			ret.Add(new Thing(year));
		}
		return ret;
	}
	
	public class Thing
	{
		public Thing(int yearBuilt)
		{
			this.ID = Guid.NewGuid().ToString();
			this.YearBuilt = yearBuilt;
		}
		public string ID { get; set; }
		public int YearBuilt { get; set; }
		
	}
	
	
	public class AgeRange {
		public AgeRange(int lower, int upper) { Lower = lower; Upper = upper;}
		public int Lower {get;set;} = -1;
		public int Upper {get;set;} = -1;
	}
}
