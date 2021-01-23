    public class Reservation
    {
        public int ReservationID
        {
            get;
            set;
        }
        [Required(ErrorMessage="Please provide a valid date")]
        public DateTime ReservationDate
        {
            get;
            set;
        }
        public DateTime ReservationEnd { get; set; }
        public DateTime EntryDate
        {
            get;
            set;
        }
        public DateTime UpdatedOn
        {
            get;
            set;
        }
        public decimal Ammount
        {
            get;
            set;
        }
        public decimal? Discount { get; set; }
        [DataType(DataType.MultilineText)]
        public string ServiceDetails { get; set; }
       
        [DataType(DataType.MultilineText)]        
        public string Remarks { get; set; }
        public String  PaymentMethod { get; set; }
        public string VoucherNumber { get; set; }
        
        public int ServiceID
        {
            get;
            set;
        }
        public virtual Service Service
        {
            get;
            set;
        }
        public string EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual User Employee { get; set; }
        
        public string ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual User Client { get; set; }
        
        public string StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual User Student { get; set; }
    }
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            this.HasOptional(r => r.Client).WithMany().WillCascadeOnDelete(true);
            this.HasOptional(r => r.Employee).WithMany().WillCascadeOnDelete(false);
            this.HasOptional(r=>r.Student).WithMany().WillCascadeOnDelete(false);
        }
    }
