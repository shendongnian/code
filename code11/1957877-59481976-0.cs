    public class Contact
    {
        [Key]
        public Guid ContactId
        { get; set; }
        public Guid UserId
        { get; set; }
        [ForeignKey("UserId")]
        public User User
        { get; set; }
        public string Name
        { get; set; }
        [Required]
        public string VatId
        { get; set; }
        public string City
        { get; set; }
        public string Address
        { get; set; }
        //[StringLength(36)]
        public Guid? RefContactId
        { get; set; }
        [ForeignKey("RefContactId")]
        public Contact RefContact
        { get; set; }
        public ICollection<Contact> SubContacts { get; set; }
    }
