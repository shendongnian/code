	private static DataTable CreateDataTable()
	{
		var table = new DataTable("FileUploads");
		table.Columns.AddRange(new[]{
			new DataColumn("Id", typeof(int))
			{
				AutoIncrement = true,
				Unique = true
			},
			new DataColumn("FileName", typeof(string)),
			new DataColumn("FilePath", typeof(string)),
            // more columns here
		});
		
		table.PrimaryKey = new []{ table.Columns["id"] };
		return table;
	}
