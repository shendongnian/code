    public abstract class Vehicle {
        public Vehicle() { Console.WriteLine("Honda Civic"); } 
    }
    
    public class Vehicle4Wheels : Vehicle {
        public Vehicle4Wheels() { Console.WriteLine("Derived111 class Constructor."); }
    }
    
    public class SportCar : Vehicle4Wheels {
        public SportCar() { Console.WriteLine("Derived222 class Constructor."); 
    }
