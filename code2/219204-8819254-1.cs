    namespace ConsoleApplication1
    {
        using CityTemp = Tuple<double, string>;
    
        class Program
        {
            static void Main(string[] args)
            {
                var result = GetTemp(10, 10);
                Console.WriteLine("Temp for {0} is {1}", result.Item2, result.Item1);
            }
    
            // You give a lat & a long and you get the closest city & temp for it
            static CityTemp GetTemp(double lat, double @long)
            {
                // just for example            
                return new CityTemp(10, "Mordor");
            }
        }
    }
