    public class Appointment
    {
        [JsonProperty("patient_id")]
        public string PatientId { get; set; }
        [JsonProperty("patient_name")]
        public string PatientName { get; set; }
        [JsonProperty("physician_name")]
        public string PhysicianName { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }]
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("appointments")]
        public List<Appointment> Appointments { get; set; }
    }
