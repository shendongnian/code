    static class StringExtensions
    {
    	public static IEnumerable<string> ToHex(this String s) {
    		if (s == null)
    			throw new ArgumentNullException("s");
    		
    		int mod4Len = s.Length % 8;
    		if (mod4Len != 0)
    		{
    			// pad to length multiple of 8
    			s = s.PadLeft(((s.Length / 8) + 1) * 8, '0');
    		}
    		
    		int numBitsInByte = 8;
    		for (var i = 0; i < s.Length; i += numBitsInByte)
    		{
    			string eightBits = s.Substring(i, numBitsInByte);
    			yield return string.Format("{0:X2}", Convert.ToByte(eightBits, 2));
    		}
    	}
    }
