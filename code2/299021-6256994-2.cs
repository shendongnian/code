    class Program {
        static void Main(string[] args) {
            dynamic settings = new DynamicSettings(ConfigurationManager.AppSettings);
            Console.WriteLine("The value of 'FavoriteNumber' is: " + settings.FavoriteNumber);
        }
    }
