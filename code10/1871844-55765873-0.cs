	using System;
	public class chars
	{
		public static void Main(string[] args)
		{
			char[,] charArray = new char[,] {{'*','*','*','*','*'}, 
											 {'*','*','.','*','*'},
											 {'*','*','*','*','*'},
											 {'*','*','*','*','.'}};
			int[,] holdIndex = new int[4, 5];
			
			for(int i = 0; i<4; i++)  // get allindexes containing '.'
			{
				for(int j = 0; j<5; j++)
				{
					if(charArray[i,j] == '.')
						holdIndex[i,j] = 1;
					else
						holdIndex[i,j] = 0;
				}
			}
			
			for(int i = 0; i<4; i++)
			{
				for(int j = 0; j<5; j++)
				{
					if(holdIndex[i,j] == 1)
					{
						if(i!=0)
							charArray[i-1,j] = '.';  //up
						if(j!=0)
							charArray[i,j-1] = '.';  // left
						if(j!=4)
							charArray[i,j+1] = '.';  //right 
						if(i!=3)
							charArray[i+1,j] = '.';  //down
					}
				}
			}
			
			for(int i = 0; i<4; i++)
			{
				for(int j = 0; j<5; j++)
				{
					Console.Write(charArray[i,j]);
				}
				Console.WriteLine();
			}
			Console.Read();
		}
	}
