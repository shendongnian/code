        public static class TemperatureConverter
        {
            public static double CelsiusToFahrenheit(string temperatureCelsius)
            {
                // Convert argument to double for calculations.
                double celsius = System.Double.Parse(temperatureCelsius);
        
                // Convert Celsius to Fahrenheit.
                double fahrenheit = (celsius * 9 / 5) + 32;
        
                return fahrenheit;
            }
        
            public static double FahrenheitToCelsius(string temperatureFahrenheit)
            {
                // Convert argument to double for calculations.
                double fahrenheit = System.Double.Parse(temperatureFahrenheit);
        
                // Convert Fahrenheit to Celsius.
                double celsius = (fahrenheit - 32) * 5 / 9;
        
                return celsius;
            }
        }
    
    class TestTemperatureConverter
    {
        static void Main()
        {
            System.Console.WriteLine("Please select the convertor direction");
            System.Console.WriteLine("1. From Celsius to Fahrenheit.");
            System.Console.WriteLine("2. From Fahrenheit to Celsius.");
            System.Console.Write(":");
    
            string selection = System.Console.ReadLine();
            double F, C = 0;
    
            switch (selection)
            {
                case "1":
                    System.Console.Write("Please enter the Celsius temperature: ");
                    F = TemperatureConverter.CelsiusToFahrenheit(System.Console.ReadLine());
                    System.Console.WriteLine("Temperature in Fahrenheit: {0:F2}", F);
                    break;
    
                case "2":
                    System.Console.Write("Please enter the Fahrenheit temperature: ");
                    C = TemperatureConverter.FahrenheitToCelsius(System.Console.ReadLine());
                    System.Console.WriteLine("Temperature in Celsius: {0:F2}", C);
                    break;
    
                default:
                    System.Console.WriteLine("Please select a convertor.");
                    break;
            }
        }
    }
