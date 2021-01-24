protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer(myConnectionString);
Or enable it when using AddDbContext
.AddDbContext<BloggingContext>(
    b => b.UseLazyLoadingProxies()
          .UseSqlServer(myConnectionString));
**2. Lazy Loading without Proxy:** 
a. Injecting the ILazyLoader service into an entity, as described in Entity Type Constructors. For example:
public class Blog
{
    private ICollection<Post> _posts;
    public Blog()
    {
    }
    private Blog(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
    private ILazyLoader LazyLoader { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts
    {
        get => LazyLoader.Load(this, ref _posts);
        set => _posts = value;
    }
}
-----------------------
**By default, EF Core won't use lazy load with proxy, but if you want to use proxy, please follow 1st approach.** 
