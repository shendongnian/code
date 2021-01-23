    for (int playerID = 1; playerID <= participants; playerID++)
    {
    	checkA = Check4forsequenceof4(matrix); //method A
    	if (checkA == 0)
            continue;
    
    	Console.WriteLine(p + "completed check A");
    
        if (checkB == 0)
    		continue;
        Console.WriteLine(p + "completed check B");
    
        if (checkC == 0)
            	continue;
        Console.WriteLine(p + "completed check C");
    }
