 var nearestKey = MonthDayBuckets.Keys.Where(x => x >= endMonth.Month).Min();
 var nearestDate = new DateTime(DateTime.Now.Year,nearestKey,MonthDayBuckets[nearestKey]); // or whatever the year it needs to be represent
Though above query would get you the result, I would suggest you define a structure to store the Range itself, rather than using Dictionary
For example,
public class Range
{
	public MonthDate StartRange{get;set;}
	public MonthDate EndRange{get;set;}
	public Range(MonthDate startRange,MonthDate endRange)
	{
		StartRange = startRange;
		EndRange = endRange;
	}
}
public class MonthDate
{
	public MonthDate(int month,int date)
	{
		Month = month;
		Date = date;
	}
	public int Month{get;set;}
	public int Date{get;set;}
	
    //Depending on if your Ranges are inclusive or not,you need to decide how to compare
	public static bool operator >=(MonthDate source, MonthDate comparer)  
	{
		return source.Month>= comparer.Month && source.Date>=comparer.Date;
	}
	
	public static bool operator <=(MonthDate source, MonthDate comparer)
	{
		return source.Month<= comparer.Month && source.Date<=comparer.Date;
	}
}
Now you could define ranges as
 var dateRanges = new Range[]
	 {
	 	new Range(new MonthDate(12,31),new MonthDate(3,31)),
		new Range(new MonthDate(3,31),new MonthDate(6,30)),
		new Range(new MonthDate(6,30),new MonthDate(12,31)),
	 };
var result = dateRanges.First(x=>x.StartRange <= new MonthDate(endMonth.Month,endMonth.Day) && x.EndRange >= new MonthDate(endMonth.Month,endMonth.Day));
