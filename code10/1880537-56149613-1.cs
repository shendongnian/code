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
[Live demo](https://dotnetfiddle.net/RSPmVU). 
