    class VehiculeCreation
    { public static List<Type> vehicules = new List<Type> { typeof(Car), typeof(motor) };
    enum Vehicule 
    {
        Car = 0,
        Motor = 1,
    };
   
    static void Main()
    {
        vehicule cars = GenerateVehicules((int)Vehicule.Car);
        vehicule motors = GenerateVehicules((int)Vehicule.Motor);
        cars.print();
        motors.print();
     
        Console.ReadLine();
    }
    public abstract class vehicule
    {
        public abstract void print();
    }
    public class Car : vehicule
    {
        public override void print() {Console.WriteLine("I am a car");}
    }
    public class motor : vehicule
    {
        public override void print() { Console.WriteLine("I am a motor"); }
    }
    public static vehicule GenerateVehicules(int index)
    {
        return (vehicule)System.Activator.CreateInstance(vehicules[index]);
    }
 
}
