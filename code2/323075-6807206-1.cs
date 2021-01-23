    static ulong EncodeDouble(double d)
    {
        long ieee = System.BitConverter.DoubleToInt64Bits(d);
        ulong widezero = 0;
        return ((ieee < 0)? widezero: ((~widezero) >> 1)) ^ (ulong)~ieee;
    }
 
    static double DecodeDouble(ulong lex)
    {
        ulong widezero = 0;
        long ieee = (long)(((0 <= (long)lex)? widezero: ((~widezero) >> 1)) ^ ~lex);
        return System.BitConverter.Int64BitsToDouble(ieee);
    }
