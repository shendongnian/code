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
Add Library navigation property on the book
public class Book
{
    public int Id { get; set; }
    public Library Library { get; set; }
    ...
}
and then you can update the library property on the books using only their ids
var library = new Library { Name = "My library" };
DbContext.Libraries.Add(library);
var bookIds = new int[] {1, 2};
foreach(var bookId in bookIds) {
    var book = new Book { Id= bookId, Library = library};
    DbContext.Attach(book);
    DbContext.Entry(book).Property(b => b.LibraryId).IsModified = true;
}
DbContext.SaveChanges();
