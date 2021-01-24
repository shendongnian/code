    public class Example
    {
       public static void Main()
       {
          string[] dateStrings = {"2008-05-01T07:34:42-5:00", 
                                  "2008-05-01 7:34:42Z", 
                                  "Thu, 01 May 2008 07:34:42 GMT"};
          foreach (string dateString in dateStrings)
          {
             DateTime convertedDate = DateTime.Parse(dateString);
             Console.WriteLine($"Converted {dateString} to {convertedDate.Kind} time {convertedDate}");
          }                              
       }
    }
