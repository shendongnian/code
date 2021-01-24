		Stopwatch sw = new Stopwatch();
		DataTable dt = new DataTable();
		dt.Columns.Add("Column1");
		dt.Columns.Add("Column2");
		dt.Columns.Add("Column3");
		Random r = new Random();
		sw.Start();
		for (int i = 0; i < 1_000_000; i++)
		{
			dt.Rows.Add(dt.NewRow());
			for (int j = 0; j < 3; j++)
				dt.Rows[i][j] = r.Next().ToString();
		}
		Console.WriteLine("Row Count:" + dt.Rows.Count);
		Console.WriteLine("Rows with the digit 0:" + dt.Rows.Cast<DataRow>().Count(row=>((string)row[0]).Contains('0')));
		sw.Stop();
		Console.WriteLine("Time taken to fill table:" + sw.Elapsed);
		sw.Reset();
		sw.Start();
		for( int i = 0 ; i < 1_000_000 ; i++)
			for (int j = 0; j < 3; j++)
				dt.Rows[i][j] = ((string) dt.Rows[i][j]).Replace('0', '1');
		sw.Stop();
		Console.WriteLine("Row Count:" + dt.Rows.Count);
		Console.WriteLine("Rows with the digit 0:" + dt.Rows.Cast<DataRow>().Count(row=>((string)row[0]).Contains('0')));
		Console.WriteLine("Time taken to update table:" + sw.Elapsed);
		Console.ReadLine();
