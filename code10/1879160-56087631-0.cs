cs
class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
second, add class name in your context model, like this
cs
class BloggingContext : DbContext
{
    public virtual DbSet<Post> Post { get; set; }
}
third, in console or package manager you must make a migration,
sh
add-migration makePostTabale
and after that update database:
sh
Update-Database
