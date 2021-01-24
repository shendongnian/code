    public class Parking
    {
        public int parkingID { get; set; }
        public bool parkingIsReserved { get; set; }
        public bool parkingIsPurchased { get; set; }
        public bool parkingisReservedBy { get; set; }
        public DateTime DateTime { get; set; }
    
       [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(**conferenceID** >= 0 && conferenceID <= totalConferences);
            Contract.Invariant(**parkingID** >= 0 && parking <= maxParkingSpaces);
            Contract.Invariant(parkingID <= availableParkings);
        }
    }
