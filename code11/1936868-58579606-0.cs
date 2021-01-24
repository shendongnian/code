    public class Model
    {
         public int Id {get;set;}
         ........ // Other Properties
         public int Value {get; set;} 
         [TimeStamp]
         public byte[] RowVersion { get; set; }
    }
