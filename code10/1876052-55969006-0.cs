    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                ctx.Blogs.Add(new Blog { Name = "5" });
                ctx.SaveChanges();
            }
            using (var ctx = new BlogContext())
            {
                var blog = ctx.Blogs.Single(b => b.Name.Trim().ToLower() == "5");
                Console.WriteLine(blog.Name);
            }
        }
    }
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=npgsql_tests;Password=npgsql_tests");
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
