    public interface IApplicationDbContext<T> where T: class
    {
        //Identity Management
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        
        //Datamanagement
        DbSet<T> DataSet { get; set; } //the Dataset of T
        DbSet<U> Set<U>() where T: class; //get other DataSets
        int SaveChanges(); //save the changes
    }
