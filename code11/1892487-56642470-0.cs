    // @nuget: EntityFramework
    
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    
    public class Program
    {
    	public static void Main()
    	{
    		InsertData();
    		
    		using (var context = new BookStore())
    		{
    			var authors = context.Authors.Include(a => a.Books).ToList();
    			
    			DisplayData(authors);
    			
    			foreach(var a in authors){
    				a.Books.ToList().ForEach(x=>x.Title = x.Title + " 2019");
    			}
    			
    			Console.WriteLine();
    			
    			authors = context.Authors.Include(a => a.Books).ToList();
    			DisplayData(authors);
    		}
    		
    	}
    	
    	public static void DisplayData(List<Author> list)
    	{
    		foreach(var author in list)
    		{
    			Console.WriteLine("Author Name: " + author.Name);
    			Console.WriteLine("\tBook List:");
    			foreach(var book in author.Books)
    			{
    				Console.WriteLine("\t\t" + book.Title);
    			}
    		}
    	}
    	
    	public static void InsertData()
    	{
    		using (var context = new BookStore())
    		{
    			Author author1 = new Author()
    		    {
    		        Name = "Mark",
    		        Books = new List<Book>
    				{
    					new Book() { Title = "Fundamentals of Computer Programming with C#"},
    					new Book() { Title = "Java: A Beginner's Guide"},
    				}
    		    };
    			Author author2 = new Author()
    		    {
    		        Name = "Andy",
    		        Books = new List<Book>
    				{
    					new Book() { Title = "SQL: The Ultimate Beginners Guide"}
    				}
    		    };
    			
    			Author author3 = new Author()
    		    {
    		        Name = "Johny",
    		        Books = new List<Book>
    				{
    					new Book() { Title = "Learn VB.NET"},
    					new Book() { Title = "C# Fundamentals for Absolute Beginners"},
    				}
    		    };
    			
    		    context.Authors.Add(author1);
    			context.Authors.Add(author2);
    			context.Authors.Add(author3);
    
    		    context.SaveChanges();
    		}
    	}
    	
    	public class BookStore : DbContext
        {
            public BookStore() : base(FiddleHelper.GetConnectionStringSqlServer())
            {
            }
    
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
        }
    
        public class Book
    	{
        	public int Id { get; set; }
    	    public string Title { get; set; }
    	    public int AuthorId { get; set; }
    	    [ForeignKey("AuthorId")]
        	public Author Author { get; set; }
    	}
    
        public class Author
    	{
        	public int AuthorId { get; set; }
        	public string Name { get; set; }
    		public ICollection<Book> Books { get; set; }
    	}
    }
