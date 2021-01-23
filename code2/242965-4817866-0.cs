    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public ICollection<Status> Statuses { get; set; }
    }
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<News> Newses { get; set; }
    }
    public class Ctp5Context : DbContext
    {
        public DbSet<News> Newses { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
