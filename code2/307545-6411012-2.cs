    int rows = 8;
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
                Console.WriteLine("");
    		}
    	}
        x = 0;
    }
    int userSelectedHomeTeam
    int userSelectedAwayTeaM
    
    Console.WriteLine("Select home team by the number")
    for(int i = 1; i < colums; i++)
    {	
    	Console.WriteLine(data[i, 0] + " " i)
    }
    str = Console.ReadLine(); 
    userSelectedHomeTeam = int32.parse(str);
    
    Console.WriteLine("Select away team by the number")
    for(int i = 1; i < colums; i++)
    {	
    	Console.WriteLine(data[i, 0] + " " i)
    }
    str = Console.ReadLine(); 
    userSelectedAwayTeam = int32.parse(str);
    
    Console.WriteLine("Write user input")
    str = Console.ReadLine(); 
    data[userSelectedHomeTeam , userSelectedAwayTeam ] = str;
