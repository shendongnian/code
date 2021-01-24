    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                ctx.Blogs.Add(new Blog { Duration = new NpgsqlRange<LocalDate>(new LocalDate(2011, 1, 1), new LocalDate(2011, 1, 3)) });
                ctx.SaveChanges();
                var x = ctx.Blogs.FirstOrDefault(b => b.Duration.Contains(new LocalDate(2011, 1, 2)));
            }
        }
    }
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("<connection string>", o => o.UseNodaTime());
        public DbSet<Blog> Blogs { get; set; }
    }
    public class Blog
    {
        public int Id { get; set; }
        public NpgsqlRange<LocalDate> Duration { get; set; }
    }
