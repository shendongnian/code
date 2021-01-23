    void Main(){	
	    Console.WriteLine(BitConverter.IsLittleEndian);	
	    byte[] bytes = BitConverter.GetBytes(0xdcbaabcdfffe1608);
	    //Console.WriteLine(bytes);	
	    string hexStr = ByteArrayToHex(bytes);
	    Console.WriteLine(hexStr);
    }
    public static string ByteArrayToHex(byte[] data) 
    { 
       char[] c = new char[data.Length * 2]; 
       byte b; 
      if(BitConverter.IsLittleEndian)
      {
		    //read the byte array in reverse
		    for (int y = data.Length -1, x = 0; y >= 0; --y, ++x) 
		    { 
		    	b = ((byte)(data[y] >> 4)); 
			    c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30); 
			    b = ((byte)(data[y] & 0xF)); 
			    c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30); 
		    }				
	    }
	    else
	    {
		    for (int y = 0, x = 0; y < data.Length; ++y, ++x) 
		    { 
		    	b = ((byte)(data[y] >> 4)); 
		    	c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30); 
		    	b = ((byte)(data[y] & 0xF)); 
		    	c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30); 
		    }
	    }
        return String.Concat("0x",new string(c));
    }
