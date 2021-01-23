    public struct SimpleBitVector32 : IEnumerable<bool>
    {
    
    	public SimpleBitVector32(uint value)
    	{
    		this.data = value;
    	}
    
    	private uint data; 
    	public bool this[int offset]
    	{
    		get
    		{
    			unchecked
    			{
    				return (this.data & (1u << offset)) != 0;
    			}
    		}
    		set
    		{
    			unchecked
    			{
    				this.data = value ? (this.data | (1u << offset)) : (this.data & ~(1u << offset));
    			}
    		}
    	}
    
    	public IEnumerator<bool> GetEnumerator()
    	{
    		for (int i = 0; i < 32; i++)
    		{
    			yield return this[i];
    		}
    	}
    
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
