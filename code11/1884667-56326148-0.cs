public class Library
{
    private readonly ICollection<Book> _books = new List<Book>();       
    public void AddBook(Book book)
    {
        _books.Add(book);
    }
    public void ShowBooks()
    {
        foreach (Book item in _books)  
        {
            Console.WriteLine("Books found");
        }
    }
}
