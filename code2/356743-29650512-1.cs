    using System.Data.Entity;
    namespace Videos.Models
    {
    public class VideoDb : DbContext
    {
        public VideoDb()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<Video> Videos { get; set; }
    }
    }
