var result = new List<Foo>();
var lastLowerBound = DateTime.MinValue;
foreach (var range in List2)
{
    var filteredDates = List1.Where(d => d >= lastLowerBound && d <= range.StartTime)
                             .OrderBy(x => x);
    if (filteredDates.Count()> 1)
    {
        result.Add(
            new Foo { 
                StartTime = filteredDates.First(), 
                EndTime = filteredDates.Last()
        });
    }
    else
    {
        //How to make a date range if there is only one date?
    }
    lastLowerBound = range.EndTime;
}
    
    
You have populated your result with the range inferior to your filter range. 
Leaving only one range the last one. When the data is superior to the last range. 
At this point you can repeat the work outside of the foreach. 
var filteredDates = List1.Where(d => d > lastLowerBound)
                        .OrderBy(x => x).First();
                        
if (filteredDates.Count() > 1)
{
    result2.Add(new Foo { StartTime = filteredDates.First(), EndTime = filteredDates.Last() });
}   
foreach(var r in result){
    Console.WriteLine(
       "StartTime : "+r.StartTime+" \t"+
       "EndTime   : "+r.EndTime+""
    );
}
public class Foo
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
NB :  A lot of optimisation can be done.
It was just the simpliest algo based on OP description.
An exemple on how to translate english to code.
