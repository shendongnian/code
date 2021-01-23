    public class Project
    {
    	public long Id { get; set; }
    	public string Name { get; set; }
    	public Image Image { get; set; }
    }
    
    public class Image
    {
    	public string Thumbnail { get; set; }
    	public string PrimaryImage { get; set; }
    }    
    
    public class YourContext : DbContext
    {
    	public DbSet<Project> Projects{ get; set; }        
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.ComplexType<Image>();
    	}
    }
