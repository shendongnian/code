    namespace Airport
    {
        public class Airport
        {
            // Properties of Airport object:
            public int Id { get; set; }
            private List<Plane> Planes { get; set; }
    
            // Constructor method for Airport object:
            public Airport(int id, List<Plane> planes)
            {
                Id = id;
                Planes = planes;
            }
    
            // A method to remove planes from the airport's collection (just an example of how OOP could be used to make "readable" code):
            public void RemoveDepartedPlane(int id)
            {
                if(Planes.Exists(x => x.Id == id))
                {
                    Planes.Remove(Planes.Find(x => x.Id == id));
                }
                Console.WriteLine("A plane by id: {0} has been removed from available planes on this airport", id);
            }
    
            // A method to add arrived planes to the airport's collection:
            public void AddArrivedPlane(int id)
            {
                // Custom made class called Coordinate:
                Coordinate coordinate = new Coordinate(0, "Airportlocation");
                // Custom made class called GeolocationSystem (which I just came up with):
                GeolocationSystem geolocationSystem = new GeolocationSystem(0, "", "", DateTime.Now, coordinate);
                Planes.Add(new Plane(id, "", "", "", geolocationSystem));
            }
    
            // Gets the amount of used up spaces of planes on current airport
            public int GetUsedSpaces()
            {
                return Planes.Count();
            }
        }
    }
