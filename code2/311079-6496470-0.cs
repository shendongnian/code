    private byte[] GetBytes<T>(T obj) where T : struct
    {
    	int size = Marshal.SizeOf(typeof(T));
    	using(var mmf = MemoryMappedFile.CreateNew("test", size))
    	using(var acc = mmf.CreateViewAccessor())
    	{
    		acc.Write(0, ref obj);
    		var arr = new byte[size];
    		for (int i = 0; i < size; i++)
    			arr[i] = acc.ReadByte(i);
    		return arr;
    	}
    }
