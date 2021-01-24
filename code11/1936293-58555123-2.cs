    ```
    public class AppIdentityDbContext : IdentityDbContext<MyUser, MyRole, int>
    {
        ...
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MyRole>(e =>{
                e.ToTable("MyRoles");
            });
        }
    }
    ```
