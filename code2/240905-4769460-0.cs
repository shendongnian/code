     class CustomValue
     {
         public static implicit operator int(CustomValue v)  {  return 4;  }
    
         public static implicit operator float(CustomValue v) {  return 4.6f;  }
     }
    
     class Program
     {
         static void Main(string[] args)
         {
             int x = new CustomValue(); // implicit conversion 
             float xx = new CustomValue(); // implicit conversion 
         }
     }
