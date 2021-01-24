    public class CsvStudent : IdentityUser
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Course { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<CsvStudent>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
