public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public List<Post> Posts { get; set; }
}
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
In your case a `City` needs to have `StateId` and a `State` needs to have `CountryId`.
public class City
{
    public int Id { get; set; }
    (...)
    public int StateId { get; set; }
    public State State { get; set; }
}
public class State
{
   public int Id { get; set; }
   (...)
   public int CountryId { get; set; }
   public Country Country { get; set; }
}
public class Country
{
    public int Id { get; set; }
}
----
EF Core's [Data Seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding) contains an example of seeding data for one-to-many relationship model.
