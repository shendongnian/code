    public class BookingController: ControllerBase {
        private readonly BusinessManager business;
    
        //Parameterized Constructor
        public BookingController(BusinessManager business) {
            this.business = business;
        }
        //...
    }
