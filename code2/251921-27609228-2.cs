	public static void print(int no)
	{
		for (int i = 1; i <= no; i++)
		{
			for (int j = i; j <= no; j++)
			{
				Console.Write(" ");
			}
			for (int k = 1; k < i * 2; k++)
			{
				if(k % 2 != 0)
				{
				  Console.Write("*");
				}
				else
				{
				  Console.Write(" ");
				} 
			}
			Console.WriteLine();
		} 
		 Console.ReadLine();
	}
