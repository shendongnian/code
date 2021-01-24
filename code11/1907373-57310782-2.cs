    namespace Airport
    {
        public class GeolocationSystem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public DateTime TimeStamp { get; set; }
            public Coordinate Coordinate { get; set; }
    
            public GeolocationSystem(int id, string name, string type, DateTime timeStamp, Coordinate coordinate)
            {
                Id = id;
                Name = name;
                Type = type;
                TimeStamp = timeStamp;
                Coordinate = coordinate;
            }
    
            public void GetLocation()
            {
                Console.WriteLine("Location of current system is at coordinate: {0}, at time: {1}.", Coordinate.Value, TimeStamp);
            }
    
            public void GetSystemInfo()
            {
                Console.WriteLine("System name: {0} {1} and is type: {2}.", Id, Name, Type);
            }
        }
    }
