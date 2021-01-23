    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Brand = (CarBrand)1;
            myCar.Model = (CarModel)10;
            myCar.Type = (CarType)3;
            Console.WriteLine("You drive a {0} {1} {2}. Niiiice.", myCar.Brand, myCar.Model, myCar.Type);
            Console.ReadLine();
            
        }
    }
    public class Car
    {
        public CarType Type {get; set;}
        public CarBrand Brand {get; set;}
        public CarModel Model {get; set;}
        public decimal Price {get; set;}
    }
    public enum CarBrand
    {
        BMW = 1,
        Audi = 2,
        Ford = 5,
        Volkswagen = 23
    }
    public enum CarModel
    {
        M3 = 10,
        R8 = 211,
        Mustang = 3,
        Passat = 4
    }
    public enum CarType
    {
        Sedan = 3,
        Coupe = 10,
        Convertible = 21
    }
