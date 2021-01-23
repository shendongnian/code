            int n = 3;
			int[,] a = new int[,] { 
				{ 1, 2, 3 }, 
				{ 4, 5, 6 }, 
				{ 7, 8, 9 } };
			int[] b = new int[n];
			for (int i = 0; i < n; i++)
			{
				b[i] = a[i, n - 1];
				Console.Write(b[i] + " ");
			}
			Console.ReadLine();
