    public class MyResultObject {
       public DateTime date {get; set;}
       public FirstName {get; set;}
       ...
       public string ApprovedStatus {get; set;}
    
       public MyResultObject(string[] values)
       {
           date = DateTime.Parse(values[0]);
           FirstName = (string) values[1];
           ...
           etc.
       }
    }
