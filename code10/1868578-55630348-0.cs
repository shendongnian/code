    public class BookingController: ControllerBase {
        private readonly BusinessManager business;
    
        //Parameterized Constructor
        public BookingController(BusinessManager mockedBusiness) {
            this.business = mockedBusiness;
        }
        //...
    }
