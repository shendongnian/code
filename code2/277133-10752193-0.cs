    //Formats a byte[] into a binary string (010010010010100101010)
    public string Format(byte[] data)
    {
    	//storage for the resulting string
    	string result = string.Empty;
    	//iterate through the byte[]
    	foreach(byte value in data)
    	{
    		//storage for the individual byte
    		string binarybyte = Convert.ToString(value, 2);
    		//if the binarybyte is not 8 characters long, its not a proper result
    		while(binarybyte.Length < 8)
    		{
    			//prepend the value with a 0
    			binarybyte = "0" + binarybyte;
    		}
    		//append the binarybyte to the result
    		result += binarybyte;
    	}
    	//return the result
    	return result;
    }
