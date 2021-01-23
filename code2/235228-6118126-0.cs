    public class Address
    {
         //other address fields
         
         //this is what the state gets stored as in the db
         public byte StateCode { get; set; }
         //this maps our db field to an enum
         public States State
         {
             get
             {
                 return (States)StateCode;
             }
             set
             {
                 StateCode = (byte)value;
             }
         }
    }
