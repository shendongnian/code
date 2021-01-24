    public class SelectedAppDevice
    {
        public int idAppDevice { get; set; }
        public int idAppDeviceOwnerEntity { get; set; }
        public int idAppDeviceOwnerEntityRentalLocationId { get; set; }
        public string Observations { get; set; }
        public string DeviceId { get; set; }
        public string EntityRentalLocationName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedByUserName { get; set; }
        public int RentalStatus { get; set; }
        public int idAppDeviceRental { get; set; }
        public bool IsRentalStart { get; set; }
        public bool IsRentalEnd { get; set; }
        public object idNextExpectedEntityRentalLocationName { get; set; }
        public object NextExpectedEntityRentalLocationName { get; set; }
        public string LastKnownEntityRentingId { get; set; }
        public string CallerId { get; set; }
        public int RentalStatusId { get; set; }
        public int DeviceStatusId { get; set; }
    }
    
    public class Data
    {
        public string Observations { get; set; }
        public int idAppDeviceOwnerEntityRentalLocationId { get; set; }
        public int idAppDeviceOwnerEntity { get; set; }
        public List<SelectedAppDevice> selectedAppDevices { get; set; }
    }
    
    public class RootObject
    {
        public Data data { get; set; }
    }
