    namespace ConsoleApplication1
    {
        // Using an enum to store the result of 
        // parsing user input is good practice.
        public enum Scale
        {
          Unknown,
          Celsius,
          Farenheit
        }
    
    
        class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine("What sort of temperature would you like to convert?");
                string tempType = Console.ReadLine();
    
                switch(ConvertChoice(tempType))
                {
                  case Scale.Celsius:
                    // do celsius work here
                  break;
                  case Scale Farenheit:
                    // do farenheit work here
                  break;
                  default:
                    // invalid input work here  
                }
                Console.ReadLine();   
            }
    
            static Scale ConvertChoice(string tempType)
            {
              // use the framework.  also, when dealing with string equality, its best
              // to use an overload that uses the StringComparison enum.
              if(tempType.StartsWith("f", StringComparison.CurrentCultureIgnoreCase))
                return Scale.Farenheit;
              if(tempType.StartsWith("c", StringComparison.CurrentCultureIgnoreCase)))
                return Scale.Celsius;
              return Scale.Unknown;
            }
        }
}
