    public class Program
    {
      public static void Main()
      {
          decimal sequenceNumber =15;
          for (decimal i=0.1; i<1 ; i+=0.1)
          {
            decimal output = sequenceNumber +i;  
            Console.Write(output +"\n");
          }  
      }
    }
