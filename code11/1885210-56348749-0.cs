    public class RequestVm
    {
        public long Id { get; set; }
        public Dictionary<string, CallTrackingProfileVm> callTrackingProfiles { get; set; }
    }
    public class CallTrackingProfileVm
    {
        public string destinationPhoneNumber { get; set; }
        public List<PhoneNumberVm> phones { get; set; }
    }
    public class PhoneNumberVm
    {
        public int phoneType { get; set; }
        public string phoneNumber { get; set; }
        public bool destinationWhisper { get; set; }
        public bool isLocal { get; set; }
        public bool recordCalls { get; set; }
        public string countryCode { get; set; }
    }
