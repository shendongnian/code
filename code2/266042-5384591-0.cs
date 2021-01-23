    public class Car
    {
        public int ID { get; set; }
        public int CarName { get; set; }
    }
    
    
    class Program
    {
        public IEnumerable<Car> GetCars
        {
            get { return MyDb.Cars; }
        }
    
        static void Main(string[] args)
        {
            Car myCar = GetCars.FirstOrDefault(x => x.ID == 5);
            Console.WriteLine("ID: {0} | CarName {1}", myCar.ID, myCar.CarName);
        }
    }
