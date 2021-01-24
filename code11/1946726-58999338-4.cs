    // Column 1 padding
    int colPad1 = 0;
    for (int i = 0; i <= slownik.GetUpperBound(0); i++) 
    {
    	if (slownik[i, 0].ToString().Length > colPad1)
    	{
    		colPad1 = slownik[i, 0].ToString().Length;
    	}
    }
    
    // Column 2 padding
    int colPad2 = 0; 
    for (int i = 0; i <= slownik.GetUpperBound(0); i++) 
    {
    	if (slownik[i, 1].ToString().Length > colPad2)
    	{
    		colPad2 = slownik[i, 1].ToString().Length;
    	}
    }
