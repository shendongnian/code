    const int kByteBitCount= 8; // number of bits in a byte
    // constants that we use in FromBase36String and ToBase36String
    const string kBase36Digits= "0123456789abcdefghijklmnopqrstuvwxyz";
    static readonly double kBase36CharsLengthDivisor= Math.Log(kBase36Digits.Length, 2);
    static readonly BigInteger kBigInt36= new BigInteger(36);
    // assumes the input 'chars' is in big-endian ordering, MSB->LSB
    static byte[] FromBase36String(string chars)
    {
    	var bi= new BigInteger();
    	for (int x= 0; x < chars.Length; x++)
    	{
    		int i= kBase36Digits.IndexOf(chars[x]);
    		if (i < 0) return null; // invalid character
    		bi *= kBigInt36;
    		bi += i;
    	}
    
    	return bi.ToByteArray();
    }
    // characters returned are in big-endian ordering, MSB->LSB
    static string ToBase36String(byte[] bytes)
    {
        // Estimate the result's length so we don't waste time realloc'ing
        int result_length= (int)
            Math.Ceiling(bytes.Length * kByteBitCount / kBase36CharsLengthDivisor);
        // We use a List so we don't have to CopyTo a StringBuilder's characters
        // to a char[], only to then Array.Reverse it later
        var result= new System.Collections.Generic.List<char>(result_length);
    
        var dividend= new BigInteger(bytes);
        // IsZero's computation is less complex than evaluating "dividend > 0"
        // which invokes BigInteger.CompareTo(BigInteger)
        while (!dividend.IsZero)
        {
            BigInteger remainder;
            dividend= BigInteger.DivRem(dividend, kBigInt36, out remainder);
            int digit_index= Math.Abs((int)remainder);
            result.Add(kBase36Digits[digit_index]);
        }
    
        // orientate the characters in big-endian ordering
        result.Reverse();
        // ToArray will also trim the excess chars used in length prediction
        return new string(result.ToArray());
    }
