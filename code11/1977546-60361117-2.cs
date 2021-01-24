cs
public class Author
{
    public Author()
    {
        Blogs = new List<Blog>();
    } 
  
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<Blog> Blogs { get; set; }
}
Or use property initializer for that (it's available from C# 6). In this case make sense to make a property `readonly` (to prevent overwriting a property from outside)
cs
public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<Blog> Blogs { get; } = new List<Blog>();
}
