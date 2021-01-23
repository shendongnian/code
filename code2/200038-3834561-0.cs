    class Contact {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	
    	public override string ToString()
    	{
    		return string.Format("{0}:{1}", Id, Name);
    	}
    	
    	static private IEqualityComparer<Contact> comparer;
    	static public IEqualityComparer<Contact> Comparer {
    		get { return comparer ?? (comparer = new EqualityComparer()); }
    	}
    	
    	class EqualityComparer : IEqualityComparer<Contact> {
    	   	bool IEqualityComparer<Contact>.Equals(Contact x, Contact y)
    		{
    			if (x == y) 
    				return true;
    			
    			if (x == null || y == null)
    				return false;
    		
    			return x.Name == y.Name; // let's compare by Name
    		}
    	
    		int IEqualityComparer<Contact>.GetHashCode(Contact c)
    		{
    			return c.Name.GetHashCode(); // let's compare by Name
    		}
    	}
    }
    	
    class Program {
    	public static void Main()
    	{
    		var list = new List<Contact> {
    			new Contact { Id = 1, Name = "John" },
    			new Contact { Id = 2, Name = "Sylvia" },
    			new Contact { Id = 3, Name = "John" }
    		};
    		
    		var distinctNames = list.Distinct(Contact.Comparer).ToList();
    		foreach (var contact in distinctNames)
    			Console.WriteLine(contact);
    	}
    }
