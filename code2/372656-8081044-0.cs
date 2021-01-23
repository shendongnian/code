    public enum BodyStyle
    {
        Convertable,
        Hatchback,
        Sports,
        Sedan
    }
    
    public class Car
    {
      public Car(String cName, BodyStyle cBodyStyle)
      {
         carname = cName;
         this.BodyStyle = cBodyStyle;
      }
    
    
         public string carname
         {
             get;
             set;
         }
    
         public BodyStyle BodyStyle
         {
             get;
             private set;
         }
    }
