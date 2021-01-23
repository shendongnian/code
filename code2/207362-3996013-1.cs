        static void Main(string[] args)
        {
            var c = Temp.FromCelsius(30);
            var f = Temp.FromFahrenheit(20);
            var k = Temp.FromKelvin(20);
            var total = c + f + k;
            Console.WriteLine("Total temp is {0}F", total.Fahrenheit);
        }
