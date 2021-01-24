    public class Account {
        public Email Email { get; private set; }
        // other stuff
    }
    public class Car {
        public LicencePlace LicencePlace { get; private set; }
        // other stuff
    }
    public class CarRental {
        public Email AccountEmail { get; private set; }
        public LicencePlace CarLicencePlace { get; private set; }
        // other stuff
    }
