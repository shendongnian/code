    public class Customer 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerCode { get; set; }
        public virtual Destination destination { get; set; }//relationship with Destination
    }
    public class Destination 
    {
        
        public virtual Customer customer { get; set; }//relationship with Customer 
        [Key, ForeignKey("User")]
        public int CustomerCode { get; set; }
    }
