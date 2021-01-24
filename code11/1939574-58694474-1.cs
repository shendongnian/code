    static void Main( string[ ] args )
    {
        Console.WriteLine("Input a number between 1-100");
        Console.Write("");
        string number = Console.ReadLine();
        int x = Convert.ToInt32(number);
        do
        {
        	if (x > 0 && x <= 101) 
        	{
        		Console.WriteLine(x++);
        	}
        	else
        	{
        		Environment.Exit( 0 ); // when insert 0 or 101
        	}
        } while (x < 102);
        Console.ReadKey( ); // when write all numbers, wait for a key to close program
    }
