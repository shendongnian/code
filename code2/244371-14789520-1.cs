    public static bool GetBit(this byte b, int bitNumber)
    {
    	System.Collections.BitArray ba = new BitArray(new byte[]{b});
    	return ba.Get(bitNumber);
    }
