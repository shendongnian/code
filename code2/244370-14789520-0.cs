    public static bool GetBit(this byte b, int bitNumber)
    {
    	//black magic goes here
    	System.Collections.BitArray ba = new BitArray(new byte[]{b});
    	return ba.Get(bitNumber);
    }
