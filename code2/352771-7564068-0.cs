    public unsafe struct MyStruct
    {
    	private fixed uint myUints[32];
    	public uint[] MyUints
    	{
    		get
    		{
    			fixed (uint* ptr = myUints)
    			{
    				uint[] result = new uint[32];
    				for (int i = 0; i < result.Length; i++)
    					result[i] = ptr[i];
    				return result;
    			}
    		}
    		set
    		{
                // TODO: make sure value's length is 32
    			fixed (uint* ptr = myUints)
    			{
    				for (int i = 0; i < value.Length; i++)
    					ptr[i] = value[i];
    			}
    		}
    	}
    }
