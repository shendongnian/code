    public class Box : Control
    {
       // ...existing code
    
       private string extraInfo;
       public string ExtraInfo
       {
          get
          {
             return extraInfo;
          }
          set
          {
             extraInfo = value;
          }
       }
    
    }
