public struct Cars
{    
   public int HondaValue {get;set;}    
   public int fordValue {get;set;}
   public int totalValue 
   { 
      get 
      {
         return HondaValue + fordValue;
      }
   }
}
