    void Main()
    {
    	var colorBuffer = new RGBA [10];
    	for (int i = 0; i < colorBuffer.Length; i++)
    	{
    		colorBuffer[i].red = (byte)i;
    		Console.WriteLine(colorBuffer[i].red);
    	}
    }
    
    // Define other methods and classes here
    struct RGBA { public byte red, green, blue, alpha; }
