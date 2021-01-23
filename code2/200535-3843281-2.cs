    public class ParkingSpace
    {
        int ID { get; set; }
        int Length { get; set; }
        IEnumerable<ParkingSpaceLease> Leases { get; set; }
        LeaseQuote GetQuote(Customer customer/*, other relevant parameters */) { ... }
    }
    public class ParkingSpaceLease
    {
        int ID { get; set; }
        DateTime OpenDate { get; set; }
        DateTime CloseDate { get; set; }
        Customer Customer { get; set; }
    }
    public class LeaseQuote
    {
        //Properties
        ParkingSpaceLease GetLease();
    }
