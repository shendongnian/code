    public class RateResponse
    {
        public string scac { get; set; }
        public string service { get; set; }
        public string service_human { get; set; }
        public string carrier { get; set; }
        public string carrier_human { get; set; }
        public int estimated_transit_days { get; set; }
        public string cost { get; set; }
    }
    
    public class RateResponseError
    {
        public string carrier { get; set; }
        public string message { get; set; }
    }
    
    public class RootObject
    {
        public bool success { get; set; }
        public List<RateResponse> rate_response { get; set; }
        public List<RateResponseError> rate_response_errors { get; set; }
        public string pick_ticket_number { get; set; }
        public string bol_number { get; set; }
    }
