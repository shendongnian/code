    public class Driversched
    {
        public int DriverID { get; set; }  // foreign key
        public DateTime Date { get; set; }
        public bool IsScheduled { get; set; }
        public virtual Driver Driver { get; set; }
    }
