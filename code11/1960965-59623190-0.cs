    using System.Data.Entity;
    
    namespace YourNamespace
    {
    	public class ApplicationDbContext : DbContext
    	{
    		public ApplicationDbContext()
    			: base("Name=ApplicationDbContextConnection")
    		{
    		}
    
    		public virtual DbSet<crm.tbljobs> Jobs { get; set; }
    		public virtual DbSet<TaskOrder> TaskOrders { get; set; }
    		public virtual DbSet<Projects> Projectz{ get; set; }
