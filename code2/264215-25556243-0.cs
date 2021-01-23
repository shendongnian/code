    public class Customer{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]//The database generates a value when a row is inserted. 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //The database generates a value when a row is inserted or updated.
        public DateTime DateCreated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.IComputed)]//The database generates a value when a row is inserted or updated.
        public DateTime DateUpdated { get; set; }
    }
