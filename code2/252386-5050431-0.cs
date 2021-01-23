    public class Post {
        [Key, DatabaseGenerated(DatabaseGenerationOption.Identity)]
        public int Id { get; set; }
        public virtual ICollection<PostHistory> Histories { get; set; }
    }
    public class PostHistory {
        [Key, DatabaseGenerated(DatabaseGenerationOption.Identity)]
        public int Id { get; set; }
        
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    
       //... properties of the posthistory object
    }
