    public class HotelContext:DbContext
        {
    public HotelContext():base("type the **name** as you have in the connectionString")
            {
                this.Configuration.LazyLoadingEnabled = false;
    
            }
          public DbSet<Hotel> Hotels { get; set; }
