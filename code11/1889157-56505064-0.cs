public class Book
{
    public int Id { get; set; }
    public int LibraryId { get; set; }
    public string Title { get; set; }
    public Bookshelf Bookshelf { get; set; }
    public int BookshelfId { get; set; }
}
Then you can do:
DbContext.Add(new Book { LibraryId = 1, BookshelfId = 1});
DbContext.SaveChanges();
*What if, for example, I want to create a new library, and relate it to some already existing books*
first of all you should initialize your book list on the library
public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
    public Library() {
        Books = new List<Book>();
    }
}
Then you can add the books to your new library
var myBook = dbContext.Books.FirstOrDefault(b => b.Id = bookId);
var newLibrary = new Library { Name = "My new library" };
newLibrary.Books.Add(myBook);
dbContext.SaveChanges();
