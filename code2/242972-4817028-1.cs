    class Program
        {
            static void Main(string[] args)
            {
    	    TempConverter converter = new TempConverter();
                Console.WriteLine("What sort of temperature would you like to convert?");
                converter.degreeType = Console.ReadLine();
                ConvertChoice(converter.degreeType);
                Console.WriteLine("Please enter a temperature to convert: ");
                converter.userTemp = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(Double.ToString(converter.convert());  
            }
    
            static void ConvertChoice(string tempType)
            {
                switch (tempType)
                {
                    case "farenheit":
                        Console.WriteLine("Farenheit it is!");
                        return;
                    case "celsius":
                        Console.WriteLine("Celsius it is!");
                        return;
                    default:
                        Console.WriteLine("Invalid type, please type farenheit or celsius.");
                        return;
                }
            }
        }
