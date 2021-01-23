    public class GraphValues
    {
         public int? Min { get; set; } 
         public int? Max { get; set; }
         // etc...
         public void Clear()
         {
             Min = null;
             Max = null;
             // etc...
         }
    }
