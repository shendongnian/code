     class UnsafeCode
    {
    	//mark main as unsafe
    	unsafe public static void Main()
    	{
    		int count = 99;
    		int* pointer;	//create an int pointer. 
    		pointer = &count;	//put address of count into pointer
    
    		Console.WriteLine( "Initial value of count is " + *pointer );
    		*pointer = 10;	//assign 10 to count via pointer
    		Console.WriteLine( "New value of count is " + *pointer);
    		Console.ReadLine();
           }
    }
