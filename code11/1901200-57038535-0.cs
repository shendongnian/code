DbContext
public partial class BookStoreContext : DbContext
{
  public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
  {
  }
  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Book { get; set; }
}
DbModels
public partial class Author
{
  public int Id {get;set;}
  public string Name {get;set;}
  public int Age {get;set;}
  public virtual List<Book> Books {get;set;}
}
public partial class Book
{
  public int Id {get;set;}
  public string Name {get;set;}
  public int AuthorId {get;set;}
  public virtual Author Author {get;set;}
}
DTO
class AuthorTo
{
    public int AuthorId {get;set;}
    public int AuthorName {get;set;}
    public int AuthorAge {get;set;}
}
class BookTo : AuthorTo
{
    public int BookId {get;set;}
    public int BookName {get;set;}
}
And the magic resides in a library like [`AutoMapper`][1], that will help you to map your DTO's to a `Model`
var configuration = new MapperConfiguration(cfg =>
  cfg.CreateMap<BookTo, Book>()
	.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
	.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BookName))
	.ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId)));
Then you can `Map` your `DTO` to a `Model`
...
var book = mapper.Map<BookTo, Book>(bookTo);
context.Add(books);
context.SaveChanges();
...
Hope this helps you :)
[AutoMapper docs][2]
[How to get started with AutoMapper and ASP.NET Core 2][3]
  [1]: https://automapper.org/
  [2]: https://automapper.readthedocs.io/en/latest/Getting-started.html
  [3]: https://medium.com/ps-its-huuti/how-to-get-started-with-automapper-and-asp-net-core-2-ecac60ef523f
