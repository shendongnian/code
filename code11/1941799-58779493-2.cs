    public interface NestedSetEntity
    {
    	Guid Id { get; set; }
    	int Lft { get; set; }
    }
    
    [Table("categories")]
    public class Category : NestedSetEntity
    {
    	[Required]
    	[Column("title")]
    	public string Title { get; set; }
    
    	[Column("id")]
    	public Guid Id { get; set; }
    
    	[Column("lft")]
    	public int Lft { get; set; }
    }
    
    [Table("mytable")]
    public class MyTable : NestedSetEntity
    {
    	[Column("my_id")]
    	public Guid Id { get; set; }
    
    	[Column("left_column")]
    	public int Lft { get; set; }
    }
