    public class Chicken
    {
      private string name;
      private string description;
      private int numberOfEggs;
      private int defaultEggSize;
      private int eggsDroppedInLife;
    
      public Chicken(string name, string description)
      {
         this.name = name;
         this.description = description;
      }
    
      public string name
      {
        get
        {
           return name;
        }
        set
        {
           name = value;
        }
      }
    
      // Fill in all the other properties! (variables above the constructor)
    
      public int EggsDroppedInLife
      {
        get
        {
          return eggsDroppedInLife;
        }
        set
        {
          eggsDroppedInLife = value;
        }
      }
    }
