        [System.Runtime.CompilerServices.Extension()]
    	public static IQueryable<Customer> Search(this IQueryable<Customer> query, string searchTerm)
    	{
    		string[] queryWords = searchTerm.Split(" ");
    
    		foreach (string w in queryWords) {
    			string word = w;
    			string packedWord = Pack(word);
    
    			query = query.Where(c => c.FirstName == word || c.LastName == word || c.HomePhone == packedWord || c.CellPhone == packedWord);
    		}
    		return query;
    	}
