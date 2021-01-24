    string choice = "";
    do
    {
    	choice = Console.ReadLine();
    	if (choice == "1")
    	{
    		bookRoom();
    	}
    	else if (choice == "3")
    	{
    
    		showAllRooms();
    	}
    	else if (choice == "2")
    	{
    		vacateOneRoom();
    	}
    }
    while (choice != "5");
