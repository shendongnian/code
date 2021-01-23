		private static DataTable GetTestData()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("Fruit", typeof(string));
			tbl.Columns.Add("Color", typeof(string));
			tbl.Columns.Add("Price", typeof(decimal));
			tbl.Columns.Add("Quantity", typeof(string));
			tbl.Rows.Add("Apples", "red", 2.3m, 10);
			tbl.Rows.Add("Apples", "green", 1.3m, 20);
			tbl.Rows.Add("Bananas", "yellow", 0.49m, 15);
			tbl.Rows.Add("Apples", "russet", 4.65m, 3);
			tbl.Rows.Add("Apples", "mottled", 1.26m, 2);
			tbl.Rows.Add("Bananas", "green", 1.01, 3);
			tbl.Rows.Add("Bananas", "mottled", 4.43m, 0);
			tbl.Rows.Add("Apples", "yellow", 3.45m, 40);
			tbl.Rows.Add("Oranges", "orange", 1.22m, 15);
			tbl.Rows.Add("Kinos", "orange", 3.21, 4);
			tbl.Rows.Add("Kiwis", "green", 2.21m, 15);
			tbl.Rows.Add("Apples", "brown", 0.79m, 5);
			return tbl;
		}
