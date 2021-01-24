    using System;
    using System.Collections.Generic;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		Library l1 = new Library();
    		l1.AddBook(new Book(){name = "test"});
    		l1.AddBook(new Book(){name = "test1"});
    		
    		l1.ShowBooks();
    	}
    }
    public class Book
    {
    	public string name;
    }
    public  class Library
    {
    	private  List<Book> Books = new List<Book>();
    	
    	public  void AddBook(Book b1)
        {
    		Books.Add(b1);
        }
    
        public  void ShowBooks()
        {
            foreach (Book item in Books)  
            //This foreach-loop doesn't work since its a private list.
            {
                Console.WriteLine(item.name);
            }
        }
    }
