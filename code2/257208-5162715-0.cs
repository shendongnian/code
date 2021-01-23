    public static void Main()
    {
    	Console.WriteLine("The First Character?:");
    	char firstChar = Convert.ToChar(Console.Read());
    	Console.Read(); // consume carriage return
    	Console.WriteLine("The Second Character?:");
    	char secondChar = Convert.ToChar(Console.Read());
    
    	Console.WriteLine(secondChar);
    }
