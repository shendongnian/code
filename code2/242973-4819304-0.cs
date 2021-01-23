    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool isFahrenheit;
                bool temperatureTypeHasBeenDetermined = false;
                while(!temperatureTypeHasBeenDetermined){
                    Console.WriteLine("What sort of temperature would you like to convert?");
                    string tempType = Console.ReadLine();
                    temperatureTypeHasBeenDetermined = ConvertChoice(tempType.ToLower(), out isFahrenheit);
                }
                decimal temperature;
                bool temperatureEnteredCorrectly = false;
                while(!temperatureEnteredCorrectly){
                    Console.WriteLine("Please enter a temperature to convert: ");
                    string temperatureString = Console.ReadLine();
                    temperatureEnteredCorrectly = decimal.TryParse(temperatureString, out temperature);
                }
                //Now we are ready to do the conversion
                decimal convertedTemperature = isFahrenheit ?
                                               ConvertFromFahrenheitToCelsius(temperature) :
                                               ConvertFromCelsiusToFahrenheit(temperature);
                string from = isFahrenheit ? "F" : "C";
                string to = isFahrenheit ? "C" : "F";
                
                Console.WriteLine("{0}{1} = {2}{3}", temperature, from, convertedTemperature, to);                
                Console.ReadLine();   
            }
            static decimal ConvertFromFahrenheitToCelsius(decimal temperature)
            {
                 //Implement properly
                 return 60m;
            }
            static decimal ConvertFromCelsiusToFahrenheit(decimal temperature)
            {
                 //Implement properly
                 return 42m;
            }
    
            static bool ConvertChoice(string tempType, out bool isFahrenheit)
            {
                isFahrenheit = false;
                switch (tempType)
                {
                    case "fahrenheit":
                        Console.WriteLine("Fahrenheit it is!");
                        isFahrenheit = true;
                        return true;
                    case "celsius":
                        Console.WriteLine("Celsius it is!");
                        return false;
                    default:
                        Console.WriteLine("Invalid type, please type fahrenheit or celsius.");
                        return false;
                }
            }
        }
    }
