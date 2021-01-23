    public class Trie : Dictionary<char, Trie>
    {
    	public int Frequency { get; set; }
    
    	public void Add(IEnumerable<char> chars)
    	{
    		if (chars == null) throw new System.ArgumentNullException("chars");
    		if (chars.Any())
    		{
    			var head = chars.First();
    			if (!this.ContainsKey(head))
    			{
    				this.Add(head, new Trie());
    			}
    			var tail = this.GetSafeTail(head, chars.Skip(1));
    			if (tail.Any())
    			{
    				this[head].Add(tail);
    			}
    		}
    	}
    	
    	public bool Contains(IEnumerable<char> chars)
    	{
    		if (chars == null) throw new System.ArgumentNullException("chars");
    		var @return = false;
    		if (chars.Any())
    		{
    			var head = chars.First();
    			if (this.ContainsKey(head))
    			{
    				var tail = this.GetSafeTail(head, chars.Skip(1));
    				@return = tail.Any() ? this[head].Contains(tail) : true;
    			}
    		}
    		return @return;
    	}
    	
    	private IEnumerable<char> GetSafeTail(char head, IEnumerable<char> tail)
    	{
    		return ((!tail.Any()) && (head != '$')) ? new [] { '$', } : tail;
    	}
    }
