    class Program
    {
        static int FahrenheitToCelsius(int fahrenheit)
        {
            int celsius = ((fahrenheit - 32) * 5) / 9;
            return celsius;
        }
        static void Main(string[] args)
        {
            int celsius;
            Console.WriteLine("Hello! Welcome to the sauna!");
            Console.WriteLine();
            Console.WriteLine("Please enter your desired degrees in Fahrenheit: ");
            do
            {
                // you have to declare the variable out of the scope
                int fahrenheit;
                try
                {
                    fahrenheit = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    // and here you have to handle the exception
                    Console.WriteLine("Invalid value.");
                    continue;                    
                }
                celsius = FahrenheitToCelsius(fahrenheit);
                Console.WriteLine("The sauna is now set to " + fahrenheit + " degrees Fahrenheit, which equals to " + celsius + " degrees Celsius.");
                if (celsius < 25)
                {
                    Console.WriteLine("Way too cold! Turn the heat up: ");
                }
                else if (celsius < 50)
                {
                    Console.WriteLine("Too cold, turn the heat up: ");
                }
                else if (celsius < 73)
                {
                    Console.WriteLine("Just a little bit too cold, turn the heat up a little to reach the optimal temperature: ");
                }
                else if (celsius == 75)
                {
                    Console.WriteLine("The optimal temperature has been reached!");
                }
                else if (celsius > 77)
                {
                    Console.WriteLine("Too hot! Turn the heat down: ");
                }
                else
                    Console.WriteLine("The sauna is ready!");
                {
                }
            } while (celsius < 73 || 77 < celsius);
            Console.ReadLine();
        }
    }
