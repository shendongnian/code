    public interface IPieceProvider<T>
    	{
    		T GetPiece();
    	}
    
    	public class Fleet
    	{
    		public string Test;
    	}
    
    	public class Header
    	{
    		public Fleet Fleet;
    		public string Test;
    	}
    
    	public class Source
    	{
    		public int DiscardBookId;
    	}
    
    	public partial class Book
    		: IPieceProvider<Book>, IPieceProvider<Header>, IPieceProvider<Fleet>
    	{
    		public int BookId;
    		public Header Header;
    		public string Test;
    
    		Book IPieceProvider<Book>.GetPiece()
    		{
    			return this;
    		}
    
    		Header IPieceProvider<Header>.GetPiece()
    		{
    			return Header;
    		}
    
    		Fleet IPieceProvider<Fleet>.GetPiece()
    		{
    			return Header.Fleet;
    		}
    	}
    
    	class Program
    	{
    		Book[] Books;
    
    		private KeyValuePair<T, int> GetProperty<T, TP>(Func<TP, T> propertyGetter, Source ds)
    		{
    			return Books
    				.Where(b => b.BookId == ds.DiscardBookId)
    				.Cast<IPieceProvider<TP>>()
    				.Select(p => p.GetPiece())
    				.Select(p => new KeyValuePair<T, int>(propertyGetter(p), 0))
    				.First();
    		}
    
    		static void Main(string[] args)
    		{
    			var source = new Source();
    			var prg = new Program();
    			var bookTest = prg.GetProperty((Book b) => b.Test, source);
    			var headerTest = prg.GetProperty((Header h) => h.Test, source);
    			var fleetTest = prg.GetProperty((Fleet f) => f.Test, source);
    
    			Console.ReadKey();
    		}
    	}
