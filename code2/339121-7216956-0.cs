    namespace DataProject.Model
    {
        public class AirportModel 
        {
            public List<Plane> Planes { get; set; }
            public List<Pilot> Pilots { get; set; }
            public List<Passenger> Passengers { get; set; }
            public List<Flight> Flights { get; set; }
        }
        
    }
    namespace SomeProject.Repository
    {
        public class AirportRepository
        {
            private DataProject.Model.AirportModel model;
            //constructor sets the model somehow
        
            public bool AddFlight(Plane plane, List<Passenger> passengers, DateTime time)
            {
                //Business logic
                if (plane.TimeOfDeparture != time) return false;
                
                var pilot = (from p in model.Pilots 
                             where p.Free && 
                                   p.CanAviate(plane.Id) 
                             select p).FirstOrDefault();
                //More Business logic
                if (pilot == null) return false;
                //Add plane, pilot and passenger to database
                model.Flights.add(new Flight{Pilot = pilot, Plane = plane, Passengers = passengers});
                //Even here you could decide to do some error handling, since you could get errors from database restrictions
                model.Save(); 
                return true;    
            }
            public List<Planes> GetPlanes(string from, string to)
            {
                return (from p in model.Planes 
                            where p.CityFrom == from && p.CityTo == to
                            select p).ToList();
            }
        }
    }
    namespace MVCApp.Controllers
    {
        public class AirportController
        {
            private SomeProject.Repository.AirportRepository repository;
            [HttpGet]
            public ViewResult Fly(string from, string to)
            {
                var viewModel = repository.GetPlanes(from, to);
                return View(viewModel);
            }
            [HttpPost]
            public ActionResult Fly(Plane plane, List<Passenger> passengers, DateTime time)
            {
                if (!ModelState.IsValid) return View(); 
                if (!repository.AddFlight(plane, pilot, passenger)) return View();
               return RedirectToAction("Succeed");
            }
        }
    }
