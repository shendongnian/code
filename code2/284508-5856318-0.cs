    public enum ProductStates
    {
      OutOfOrder=0,
      InStock=1,
      New=2
      ...
    }
    public class Incident
    {
      public string ProductStatusMessage 
      {
        get
          {
            switch (this.ProductID)
             {
               case (int)ProductStates.OutOfOrder:
                 return "This product will soon be out of order.";
                 break;
               case (int)ProductStates.InStock:
                 return "This product has a 10% discount!";
                 break;
                 ...
               default:
                 return string.empty;
                 break;
             }
          }
        ...
      }  
