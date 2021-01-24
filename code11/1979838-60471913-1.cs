    public class Motel
    {
    	private const int MAX = 21;
    	private readonly int[] rooms = new int[MAX];
     
    	private int GetIntegerInput()
    	{
    		int result;
    		while (!int.TryParse(Console.ReadLine(), out result))
    		{
    			Console.WriteLine("Only integers accepted, please try again.");
    		}
    		return result;
    	}
    
    	public void ShowMenu()
    	{
    		Console.Clear();
    		Console.WriteLine("The Bates Motel");
    		Console.WriteLine("===============");
    		Console.WriteLine("1. Book a room");
    		Console.WriteLine("2. Vacate a room");
    		Console.WriteLine("3. Display ALL Room Details");
    		Console.WriteLine("4. Vacate ALL rooms");
    		Console.WriteLine("5. Quit");
    		Console.Write("Enter your choice : ");
    	}
    
    	public void Run()
    	{
    		int choice;
    
    		do
    		{
    			ShowMenu();
    
    			choice = GetIntegerInput();
    
    			switch (choice)
    			{
    				case 1:
    					BookRoom();
    					break;
    				case 2:
    					VacateOneRoom();
    					break;
    				case 3:
    					ShowAllRooms();
    					break;
    				case 4:
    					VocateAllRooms();
    					break;
    				case 5:
    					Environment.Exit(0);
    					break;
    				default:
    					Console.WriteLine("Only 1 to 5 are allowed.");
    					Console.ReadLine();
    					break;
    			}
    
    		}
    		while (true);
    	}
    
    	public void BookRoom()
    	{
    		Console.Clear();
    		Console.WriteLine("\nThe Bates Motel");
    		Console.WriteLine("===============");
    		Console.WriteLine("Book a room");
    		Console.Write("Enter the room number : ");
    		var roomNumber = GetIntegerInput();
    		Console.Write("How many guests : ");
    		var guests = GetIntegerInput();
    
    		rooms[roomNumber - 1] = guests;     // make the booking
    
    		Console.WriteLine("Room " + roomNumber + " booked for " + guests + " people");
    
    	}
    
    	public void ShowAllRooms()
    	{
    		Console.Clear();
    
    		for (int i = 0; i < rooms.Length; i++)
    		{
    			Console.Write("Room " + (i + 1) + "\t\t\t" + rooms[i] + " guests \n");
    		}
    
    		Console.Read();
    	}
    
    	public void VacateOneRoom()
    	{
    		Console.Clear();
    		Console.WriteLine("Which room is being vacated");
    		var roomNumber = GetIntegerInput();
    		rooms[roomNumber - 1] = 0;
    	}
    
    	public void VocateAllRooms()
    	{
    		for (int i = 0; i < rooms.Length; i++)
    		{
    			rooms[i] = 0;                
    		}
    
    	}
    }
