    public class MyContext : DbContext
    {
    	public MyContext()
    	{
    		this.Configuration.ProxyCreationEnabled = false
    	}
    	
    	public DbSet<NiceCat> NiceCats {get; set;}
    	public DbSet<CrazyCat> CrazyCats {get; set;}
    	public DbSet<MeanCat> MeanCats {get; set;}
    
    }
