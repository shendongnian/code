    public class DtSkmDto
    {
        public int Id { get; set; }
        [Required]
        public int Ndrawing1 { get; set; }
        [Required]
        public Int16 Ndrawing2 { get; set; }
    }
    public class DtSkmContext : DbContext
    {
        public DtSkmContext()
        {
        }
        public DtSkmContext(DbContextOptions<DtSkmContext> options) : base(options)
        {
        }
        public DbSet<DtSkmDto> DtSkm { get; set; }
    }
