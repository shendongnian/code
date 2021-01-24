            long row, col;
			string line = Console.ReadLine();
			string delim = " ";
			string[] lineSplitter = line.Split(delim);
			row = long.Parse(lineSplitter[0]);
			col = long.Parse(lineSplitter[1]);
			long[,] a = new long[row, col];
			for (int i = 0; i < row; i++)
			{
				string l = Console.ReadLine();
				string[] colValues = l.Split(delim);
				for (int j = 0; j < col; j++)
				{
					
					a[i, j] = int.Parse(colValues[j]);
				}
			}
