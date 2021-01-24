    public class Device
    {
        public string ID { get; set; }
        public string State { get; set; }
    }
    
    public class RootObject
    {
        public string ApiResult { get; set; }
        public List<Device> Device { get; set; }
    }
