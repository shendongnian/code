	public IList<string> ImageLoader()
	{
		DataSet data = new DataSet();
		SqlHelper db = new SqlHelper();
		data.Tables.Add(
			db.runQuery("SELECT * from Gallery")
		);
		data.Tables[0].TableName = "Images";
		foreach(DataRow row in data.Tables["Images"].Rows)
		{
			imagesList.Add(row.ItemArray[1]
					+ (row.ItemArray[2].ToString().Equals("") ? COMMA + "EMPTY" : COMMA + row.ItemArray[2])
					+ (row.ItemArray[3].ToString().Equals("") ? COMMA + "EMPTY" : COMMA + row.ItemArray[2])
					+ (row.ItemArray[4].ToString().Equals("") ? COMMA + "EMPTY" : COMMA + row.ItemArray[2])
					+ (row.ItemArray[5].ToString().Equals("") ? COMMA + "EMPTY" : COMMA + row.ItemArray[2])
					));
		}
		return imagesList;
	} 
