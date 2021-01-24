    public IActionResult Create([Bind("FlightBooking")] FlightBookingViewModel model)
    {
    
        // replace following test code with your code logic
                
        var passengers = new List<Passenger>
        {
            new Passenger
            {
                IdC = 1,
                Email = "p1@test.com"
            },
            new Passenger
            {
                IdC = 2,
                Email = "p2@test.com"
            },
            new Passenger
            {
                IdC = 3,
                Email = "p3@test.com"
            }
        };
    
        var flights = new List<Flight>
        {
            new Flight
            {
                IdF = 1,
                Name = "F1"
            },
            new Flight
            {
                IdF = 2,
                Name = "F2"
            },
            new Flight
            {
                IdF = 3,
                Name = "F3"
            }
        };
    
        var fb_viewmodel = new FlightBookingViewModel
        {
            Passengers = passengers,
            Flights = flights,
            FlightBooking = new FlightBooking()
        };
    
        return View(fb_viewmodel);
    }
