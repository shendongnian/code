       static void Main(string[] args)
        {
            double cel = 0;
            double fahr = 97;
            double max_temp = 170.6;
            double min_temp = 163.4;
            Console.WriteLine("Welcome to the sauna! We will find the optimal temperature for you! ");
            do
            {
                Console.Write("Please type in Fahrenheit: ");
                try
                {
                  fahr = double.Parse(Console.ReadLine());
                  cel = FahrenheitToCelsius(fahr);
                }
                catch
                {
                    Console.Write("Only numbers please!");
                    continue;
                }
