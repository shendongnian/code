    namespace Airport
    {
        public class Plane
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public GeolocationSystem GeolocationSystem { get; set; }
    
            public Plane(int id, string name, string type, string color, GeolocationSystem geolocationSystem)
            {
                Id = id;
                Name = name;
                Type = type;
                Color = color;
                GeolocationSystem = geolocationSystem;
            }
    
            // All sorts of methods belonging to a plane:
            public void TakeOff()
            {
                Console.WriteLine("Taking off!");
            }
    
            public void AutoPilot()
            {
                Console.WriteLine("Autopiloting...");
            }
    
            public void Land()
            {
                Console.WriteLine("Now landing...");
            }
    
            public void TurnLeft()
            {
                Console.WriteLine("Turning left.");
            }
    
            public void TurnRight()
            {
                Console.WriteLine("Turning right.");
            }
    
            public void Ascend()
            {
                Console.WriteLine("Ascending.");
            }
    
            public void Descend()
            {
                Console.WriteLine("Descending.");
            }
        }
    }
