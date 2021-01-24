public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
public class User : IdentityUser
{
    public virtual ICollection<Post> Posts { get; set; }
}
This will create a one-to-many relationship between User and Posts. Post has one User but User can have multiple Posts. With that you have also extended the IdentityUser.
