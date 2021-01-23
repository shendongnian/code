    public class ThreadItem
    {
        [Key]
        [Column(Storage="ThreadItemID")]
        public int Id { get; set; }
    
        public DateTime Created { get; set; }
    } 
