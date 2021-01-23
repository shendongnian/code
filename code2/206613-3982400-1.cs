    public class Item
    {
      public string Key{
        get 
        {
          return this.Value[0].ToString();
        }
      }
      public string Value{get;set;}
      public override string ToString()
      {
         return this.Key; 
      }
    }
