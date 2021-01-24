    public class Role
    {
        public int RoleId{ get; set; }
        public string Role{ get; set; }
    } 
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Role>().ToTable("MyCustomRoleTable");   
    
        foreach (Type entityType in GetEntityTypes())
        {
            modelBuilder.RegisterEntityType(entityType);
        }
    
        modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
    }
