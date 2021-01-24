    public class LayoutModel
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Key]
         [Column(Order = 0)]
         public int Id { get; set; }
    
         [Key]
         [Column(Order = 1)]
         //[ForeignKey("Venue")]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int VenueId { get; set; }
    
         //public virtual VenueModel Venue { get; set; } //Please correct Venue property type
    }
