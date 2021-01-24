    class Program
    {
        static void Main(string[] args)
        {
            
            // collect all user input
            Console.WriteLine("enter brand of car...");
            string brandInput = Console.ReadLine();
            Console.WriteLine("enter mileage of car...");
            string mileageInput = Console.ReadLine();
            Console.WriteLine("enter number of cylinders in the car...");
            string cylinderCountInput = Console.ReadLine();
            // create instance of car and assign user input to car properties
            Car myCar = new Car();
            myCar.Brand = brandInput;
            myCar.Mileage = mileageInput;
            myCar.NumberOfCylinders = cylinderCountInput;
            // output values in the car object to the console window
            Console.WriteLine("Brand: " + myCar.Brand);
            Console.WriteLine("Mileage: " + myCar.Mileage);
            Console.WriteLine("Cylinder Count: " + myCar.NumberOfCylinders);
            Console.WriteLine("press <ENTER> to close the console window");
            Console.ReadLine();
        }
        
    }
    public class Car
    {
        public string Brand { get; set; }
        public string Mileage { get; set; }
        public string NumberOfCylinders { get; set; }
    }
