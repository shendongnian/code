    [Table(Name = "dbo.Contacts")]
    public class Contact : BaseEntity<Contact, int>
    {
        [Column]
        public override int Id { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
    }
