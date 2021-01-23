    public class Plant
    {
        public Guid PlantID { get; set; }
        public virtual License License { get; set; }
    } 
    
    public class License
    {
         // No need to have a PlantID foreign key since the foreign key.
         public Guid LicenseID { get; set; }
         public virtual Plant Plant { get; set; }
    }
    in fluent-api (in your context class):   
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>().HasOptional(p => p.License).WithRequired(l => l.Plant);  
