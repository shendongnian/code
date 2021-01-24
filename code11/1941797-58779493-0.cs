    public class NestedSetEntity
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("lft")]
        public int Lft { get; set; }
        [Column("rgt")]
        public int Rgt { get; set; }
        [Column("depth")]
        public int Depth { get; set; }
        [Column("tree")]
        public Guid? Tree { get; set; }
    }
    [Table("categories")]
    public class Category: NestedSetEntity
    {
    	public Category()
    	{
    		Visible = true;
    		CreatedAt = DateTime.Now;
    		UpdatedAt = DateTime.Now;
    	}
    
    	[Required]
    	[StringLength(256)]
    	[Column("title")]
    	public string Title { get; set; }
    
    	[Column("visible")]
    	public bool Visible { get; set; }
    
    	[Required]
    	[Column("created_at")]
    	public DateTime CreatedAt { get; set; }
    
    	[Column("updated_at")]
    	public DateTime UpdatedAt { get; set; }
    }
