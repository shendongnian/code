    int rows = 15;
    int colums = 8;
    String[,] data = new String[colums, rows];
    int x = 0;
    int y = 0;
    
    for(; y < rows; y++)
    {
    	for (; x < colums; x++)
    	{
    		Console.Write(data[x, y] + " ");
    		if (x == (colums - 1))
    		{
    		    Console.WriteLine("");
    		}
    	}
        x = 0;
    }
