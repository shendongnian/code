    public class ApplicationUser : IdentityUser
    {
        public List<UploadFile> UploadFiles { get; set; }
    }
    public class UploadFile
    {
        [Key]
        public int FileId { get; set; }
        public string Name { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {  }
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
