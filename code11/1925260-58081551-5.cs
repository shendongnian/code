cs
public struct Cars
{    
   public int HondaValue { get; set; }    
   public int FordValue { get; set; }
   public int TotalValue 
   { 
      get 
      {
         return HondaValue + FordValue;
      }
   }
}
