        class Program
    {
        static void Main(string[] args)
        {
            var station1 = new Station("po", -7, 17);
            var station2 = new Station("wsx", -4, 6.5);
            Console.WriteLine(station1.CalculateEuDistance(station2));
            Console.ReadKey();
        }
    }
    public class Station
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Station()
        {
            
        }
        public Station(string name, double x, double y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
    public static class StationExtensions
    {
        public static double CalculateEuDistance(this Station currentStation, Station station)
        {
            return Math.Sqrt(Math.Pow(currentStation.Y - currentStation.X,2) + Math.Pow(station.Y - station.X,2));
        }
    }
