    Console.WriteLine("Input a number between 1-100");
    Console.Write("");
    string number = Console.ReadLine();
    int x = Convert.ToInt32(number);
    if( x > 0 && x < 101 )
    {
       for( int i = x; i <=101; i++ )
    	{
    		Console.Write(i);
    	}
    }
