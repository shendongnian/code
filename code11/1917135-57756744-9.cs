    class ViewModel
    {
        // This is the result table called from View.
        // Type Object is used because the output of linq query 
        // is anonymous type.
        public IEnumerable<object> Table { get; set; }
        public ViewModel()
        {
            // Define some examples 
            var dealers = new List<CarDealer>()
            {
                new CarDealer(){iID=0, name="dealer0"},
                new CarDealer(){iID=1, name="dealer1"},
                new CarDealer(){iID=2, name="dealer2"},
            };
            var garages = new List<Garage>()
            {
                new Garage(){gID = 0, gname="garage0", dealerID=0},
                new Garage(){gID = 1, gname="garage1", dealerID=1},
                new Garage(){gID = 2, gname="garage2", dealerID=2},
            };
            var repairs = new List<Repair>()
            {
                new Repair(){rID=0, date=new DateTime(2019,09,01), cost=00.99, garageID=2},
                new Repair(){rID=1, date=new DateTime(2019,09,02), cost=10.99, garageID=1},
                new Repair(){rID=2, date=new DateTime(2019,09,03), cost=20.99, garageID=0},
                new Repair(){rID=3, date=new DateTime(2019,09,04), cost=30.99, garageID=1}
            };
            // Create Linq query
            Table = from repair in repairs
                        join garage in garages on repair.garageID equals garage.gID
                        join dealer in dealers on garage.dealerID equals dealer.iID
                        select new { 
                            ID = repair.rID, 
                            Date = repair.date, 
                            Cost = repair.cost, 
                            GarageName = garage.gname, 
                            DealerName = dealer.name};
        }
    }
