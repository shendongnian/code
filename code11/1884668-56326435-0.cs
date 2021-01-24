    public class Program
    {
    	public static void Main()
    	{
    		 
    		Library.AddBook(new Book(){name = "test"});
    		Library.AddBook(new Book(){name = "test1"});
    		
    		Library.ShowBooks();
    	}
    }
    public class Book
    {
    	public string name;
    }
    public static class Library
    {
    	private static List<Book> Books = new List<Book>();
    	
    	public static void AddBook(Book b1)
        {
    		Books.Add(b1);
        }
    
        public static void ShowBooks()
        {
            foreach (Book item in Books)  
            //This foreach-loop doesn't work since its a private list.
            {
                Console.WriteLine(item.name);
            }
        }
    }
