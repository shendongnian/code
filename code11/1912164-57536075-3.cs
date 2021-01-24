    public class ApiData
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string RadiationDatabase { get; set; }
        public List<ApiSlopeAngle> OptimalSlopeAngle { get; set; }
        public ApiData()
        {
            OptimalSlopeAngle = new List<ApiSlopeAngle>();
        }
    }
