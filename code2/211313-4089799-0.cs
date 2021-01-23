    public class TopReferers
    {
        [Key]
        [Editable(false)]
        public int reffererID { get; set; }
        public int? Visits { get; set; }
        public int? Visitors { get; set; }
        public int? Prospects { get; set; }
        public int? **Customer** { get; set; }
        public String Referrer { get; set; }
    }
