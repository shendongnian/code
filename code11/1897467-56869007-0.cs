    public class Item 
    {
       [Required]
       [ForeignKey("Category")]
       public long CategoryId { get; set; }
    		
       public virtual Lookup Category { get; set; }
    }
    
    public class Lookup 
    {
        [InverseProperty("Category")]
        public virtual ICollection<Item> Categories { get; set; }
    }
