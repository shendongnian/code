    public class RootObject
    {
        public int deviceId { get; set; }
        public string longMacAddress { get; set; }
        public int shortMacAddress { get; set; }
        public string hoplist { get; set; }
        public string associationTime { get; set; }
        public int lifeCheckInterval { get; set; }
        public string lastLiveCheck { get; set; }
        public int onlineStatus { get; set; }
        public int txPowerValue { get; set; }
        public int deviceType { get; set; }
        public int frequencyBand { get; set; }
        public string lastLivecheck { get; set; }
        public int disassociationState { get; set; }
        public int firmwareUpdateActivated { get; set; }
        public int firmwareUpdatePackagesSent { get; set; }
        public int firmwareUpdatePackagesUnsent { get; set; }
        public int firmwareUpdateInProgress { get; set; }
        public string deviceIdOem { get; set; }
        public string deviceNameOem { get; set; }
        public string deviceCompanyOem { get; set; }
        public int binaryInputCount { get; set; }
        public int binaryOutputCount { get; set; }
        public int analogInputCount { get; set; }
        public int characterStringCount { get; set; }
        public List<Location> location { get; set; }
        public List<Description> description { get; set; }
        public List<object> binaryInput { get; set; }
        public List<object> binaryOutput { get; set; }
        public List<object> analogInput { get; set; }
        public List<CharacterString> characterString { get; set; }
    }
    public class Location
    {
        public string location { get; set; }
        public int locationWriteable { get; set; }
        public string changedAt { get; set; }
    }
    public class Description
    {
        public string description { get; set; }
        public int descriptionWriteable { get; set; }
        public string changedAt { get; set; }
    }
    public class CharacterString
    {
        public string characterString { get; set; }
        public int characterStringWriteable { get; set; }
        public string changedAt { get; set; }
    }
