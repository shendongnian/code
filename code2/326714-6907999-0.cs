    public class Bus
    {
        // Static constructor:
        static Bus()
        {
            System.Console.WriteLine("The static constructor invoked.");
        }    
    
        public static void Drive()
        {
            System.Console.WriteLine("The Drive method invoked.");
        }
    }
    class TestBus
    {
        static void Main()
        {
            Bus.Drive();
        }
    }
