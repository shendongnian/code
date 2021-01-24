var random = new Random();
byte[] bytes = new byte[20_000_000]; 
byte[] bytes2 = new byte[20_000_000];
ulong topBits;
int Len = bytes.Length >> 3; // >>3 is the same as / 8
ulong MASK =    0x8080808080808080;
ulong MASKINV = 0x7f7f7f7f7f7f7f7f;
//Sanity check
if((bytes.Length & 7) != 0) throw new Exception("bytes.Length is not a multiple of 8");
if((bytes2.Length & 7) != 0) throw new Exception("bytes2.Length is not a multiple of 8");
unsafe
{
    //Add 8 bytes at a time, taking into account overflow between bytes
   fixed (byte* pbBytes = &bytes[0])
   fixed (byte* pbBytes2 = &bytes2[0])
   {
	  ulong* pBytes = (ulong*)pbBytes;
	  ulong* pBytes2 = (ulong*)pbBytes2;
	  for (int i = 0; i < Len; i++)
	  {
	    topBits = (pBytes[i] ^ pBytes2[i]) & MASK;
	    pBytes[i] &= MASKINV;
	    pBytes2[i] &= MASKINV;
	    pBytes[i] += pBytes2[i];
	    pBytes[i] ^= topBits;
	  }	
   }
}
