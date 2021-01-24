    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    
    namespace Rextester
    {
    
    	public class Book
    	{
    		public string name;
    		public int id;
    		public Book(string name, int id)
    		{
    			this.name = name;
    			this.id = id;
    		}
    	}
    
    	public class Pen
    	{
    		public string name;
    		public int id;
    		public Pen(string name, int id)
    		{
    			this.name = name;
    			this.id = id;
    		}
    	}
    	public class Program
    	{
    		static List<Book> listBook = new List<Book>();
    		static List<Pen> listPen = new List<Pen>();
    		public static void Main(string[] args)
    		{
    			
    
    			listBook.Add(new Book
    			(
    				 "Book1",
    			 1
    			));
    			listBook.Add(new Book
    		("Book2",
    			  2
    			));
    
    			
    
    			listPen.Add(new Pen
    		("Pen1",
    				 1
    			));
    			listPen.Add(new Pen("Pen2", 2));
    
    
    
    			//Testing with new book list
    
    			List<Book> newListBook = new List<Book>();
    			newListBook.Add(new Book
    			("Book3",
    				  3
    			));
    			newListBook.Add(new Book
    			("Book4",
    				  4
    			));
    
    			Add(newListBook);
    
    			foreach (var item in listBook)
    			{
    				Console.WriteLine(item.name);
    
    			}
    
    
    			List<Pen> newListPen = new List<Pen>();
    			newListPen.Add(new Pen
    			("Pen3",
    				  3
    			));
    			newListPen.Add(new Pen
    			("Pen4",
    				  4
    			));
    
    			Add(newListPen);
    
    			foreach (var item in listPen)
    			{
    				Console.WriteLine(item.name);
    
    			}
    
    			Console.ReadLine();
    		}
    
    		public static void Add<T>(IEnumerable<T> obj)
    		{
    			foreach (var item in obj)
    			{
    				if (item is Book)
    				{
    					listBook.Add(item as Book);
    
    				}
    				if (item is Pen)
    				{
    					listPen.Add(item as Pen);
    
    				}
    
    			}
    		}
    	}
    }
