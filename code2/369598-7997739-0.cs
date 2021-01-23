    namespace CovarianceContravarianceTest
    {
        public interface ITravelObject { }
        
        public class Flight :  ITravelObject
        {
            public void Fly() { }
        }
    
        public class Cruise :  ITravelObject
        {
            public void Sail() { }
        }
    
        public static class LetService
        {
            public static void GoFlying(Flight flight) 
            {
                flight.Fly();
            }
    
            public static void GoSailing(Cruise cruise)
            {
                cruise.Sail();
            }  
        }
    
        public delegate void TravelServiceMethodDelegate(ITravelObject travelObject);
    
        class Program
        {
            static void Main(string[] args)
            {
                var test = new TravelServiceMethodDelegate(LetService.GoFlying);
    
                test(new Cruise());
            }
        }
    }
