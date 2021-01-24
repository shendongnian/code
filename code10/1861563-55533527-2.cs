    public class ApplicationDbContext<T> : IdentityDbContext<ApplicationUser>, IApplicationDbContext<T>
    {
        public DbSet<T> DataSet{ get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create<T>()
        {
            return new ApplicationDbContext<T>();
        }
    }
