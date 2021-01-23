    public class Bus
    {
       private static object m_object= null;
        // Static constructor:
        static Bus()
        {
            m_object = new object();
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
