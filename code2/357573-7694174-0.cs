    public class Program
    {
    	static void Main(string[] args)
    	{
    		Book book1 = new Book();
    		book1.AddPage("one");	
    	}
    }
    
    public class Book
    {
     	public string Bookname = "a";
    	public List<Page> Pages = new List<Page>();
    	
    	public void AddPage(string pageTitle)
    	{
    		Pages.Add(new Page(this, pageTitle));
    	}
    }
    
    public class Page
    {
    	Book book;
    	public Page(Book b, string pagetitle)
    	{
    		book = b;
    		Console.WriteLine(pagetitle);
    		Console.WriteLine("I'm from book '{0}'.", book.Bookname);
    	}
    }
