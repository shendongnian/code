    public class AppointmentViewModel
    {
        public string Id { get; set; }
        public bool Completed { get; set; }
        public bool Declined { get; set; }
        public string ConfirmationID { get; set; }
        public string BookingCode { get; set; }
        /// <summary>
        /// Contains all possible purposes for an appointment.
        /// </summary>
        public List<SelectListItem> Purposes { get; set; }
    }
