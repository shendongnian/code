    public class DateRange
    {
       public DateTime start { get; set;}
    
       public DateTime end { get; set;}
    
    }
.....
    [HttpPost("File/Modifications")]
    public IActionResult GetFileModificationReport(DateRange data){}
