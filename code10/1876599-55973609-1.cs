    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Column("MailAddress")]
        public string MailAddressStr
        {
            get
            {
                return MailAddress?.ToString();
            }
            set
            {
                MailAddress = new MailAddress(value);
            }
        }
          
        [NotMapped]
        public MailAddress MailAddress { get; set; }
    }
