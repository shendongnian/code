    public class ParameterDto
    {
        [FromQuery]
        public long Next { get; set; }
        
        [FromQuery]
        public string Reference { get; set; }
        [FromQuery]
        public string Option { get; set; }
    }
