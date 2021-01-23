        public class UserViewModel
    {
        public User User { get; set; }
        public List<Airport> Airports { get; set; }
        public List<String> Roles { get; set; }
        //Hack to get around non-binding of complex objects by UpdateModel
        public Guid UserAirportId
        {
            get
            {
                if (User != null && User.Airport != null)
                    return User.Airport.Id;
                return Guid.Empty;
            }
            set
            {
                if (User == null)
                    return;
                var airport = Airports.Where(m => m.Id == value).FirstOrDefault();
                if (airport == null)
                    return;
                User.Airport = airport;
            }
        }
    }
 
