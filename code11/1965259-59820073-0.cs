        int a = 66;
        int b = 77;  // Change here, you need to initialize it to 77
        do
        {
			if(a >= 22)   // Check condition for series 1 and print Error if condition is not met
			{
				Console.WriteLine(a);
            	a -= 4;
			}
			else
			{
				Console.WriteLine("Error");
			}
            
			if( b <= 99) // Check condition for series 2 and print Error if condition is not met
			{
            Console.WriteLine(b);
            b += 2;
			}
			else
			{
				Console.WriteLine("Error");
			}
        } while (a >= 22 || b <= 99); // Loop Condition
