    public class Header
    {
        public string Token { get; set; }
        public string DtTime { get; set; }
        public string ResultCode { get; set; }
        public string ResultMsg { get; set; }
    }
    
    public class Body
    {
        public string WarehouseCode { get; set; }
        public string CompanyCode { get; set; }
        public string SONo { get; set; }
        public string SOSts { get; set; }
    }
    
    public class RootObject
    {
        public Header header { get; set; }
        public List<Body> body { get; set; }
    }
