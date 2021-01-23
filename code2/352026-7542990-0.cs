       public void BuildNumbers()
    	{
    	
    		while (decimal1 <= topLimit)
    		{
    			string binary = Convert.ToString(decimal1, 2);
    			string dec = Convert.ToString(decimal1);
    			string oct = Convert.ToString(decimal1, 8);
    			string hex = Convert.ToString(decimal1, 16);
    			Console.Write(binary);
    			Console.Write('\t');
    			Console.Write(dec);
    			Console.Write('\t');
    			Console.Write(oct);
    			Console.Write('\t');
    			Console.Write(hex);
    			Console.WriteLine();
    			decimal1++;
    		}
    	}
