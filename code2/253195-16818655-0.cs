    void Main()
    {
    	"aaaabbhbbxh".GetMostFrequentCharacters().Dump();
    	((string)null).GetMostFrequentCharacters().Dump();
    	"  ".GetMostFrequentCharacters().Dump();
    	"".GetMostFrequentCharacters().Dump();    
    }
    
    static class LinqPadExtensions {
    	public static IEnumerable<char> GetMostFrequentCharacters(this string str) {
    		if (string.IsNullOrEmpty(str))
    			return Enumerable.Empty<char>();
    			
    		var groups = str.GroupBy(x => x).Select(x => new { Letter = x.Key, Count = x.Count() }).ToList();
    		var max = groups.Max(g2 => g2.Count);
    		return groups.Where(g => g.Count == max).Select(g => g.Letter);
    	}
    }
