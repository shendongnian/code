    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool Status { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
    public class AppointmentViewModel
    {
        public DateTime AppointmentDate { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public string PatientIdentityName { get; set; }
        public string DoctorName { get; set; }
    }
