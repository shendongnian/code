    using System;
    
    static class Program
    {
    	// BASIC variables are always global and zero-initialized.
    	static int n_int = 0;
    
    	static void Gosub(int lineNumber)
    	{
    		switch (lineNumber)
    		{
    			case 10: // 10 PRINT "Enter an integer: ";N%
    				Console.Write("Enter an integer: ");
    				// By default, the end of each line falls thru to next line number
    				goto case 20;
    			case 20: // 20 INPUT N%
    				n_int = int.Parse(Console.ReadLine());
    				goto case 30;
    			case 30: // 30 IF N% MOD 2 = 0 THEN GOTO 60
    				if (n_int % 2 == 0)
    				{
    					Gosub(60);
    					return;
    				}
    				goto case 40;
    			case 40: // 40 PRINT N%;" is odd."
    				Console.WriteLine("{0} is odd.", n_int);
    				goto case 50;
    			case 50: // 50 GOTO 70
    				Gosub(70);
    				return;
    			case 60: // 60 PRINT N%;" is even."
    				Console.WriteLine("{0} is even.", n_int);
    				goto case 70;
    			case 70: // 70 PRINT "Goodbye."
    				Console.WriteLine("Goodbye.");
    				// Falling off the end of the program exits it.
    				return;
    		}
    	}
    
    	static void Main()
    	{
    		Gosub(10);
    	}
    }
