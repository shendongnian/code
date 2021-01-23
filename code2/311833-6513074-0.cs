    public static void InsertRecordBasedOnView(String goodNameForTextBoxOne,  String goodNameForTextBoxTwo, String goodNameForTextBoxFive, String goodNameForTextBoxThree, String UserName)
	{
		const string query = "insert into Table1(col1,col2,col3,col4,col5,col6,col7) values (@valueOne, @valueTwo, @valueThree, @valueFour, @valueFive, @valueSix, @valueSeven)";
		SqlParameter columnOne = new SqlParameter("@valueOne", SqlDbType.NVarChar);
		SqlParameter columnTwo = new SqlParameter("@valueTwo", SqlDbType.NVarChar);
		SqlParameter columnThree = new SqlParameter("@valueThree", SqlDbType.NVarChar);
		SqlParameter columnFour = new SqlParameter("@valueFour", SqlDbType.NVarChar);
		SqlParameter columnFive = new SqlParameter("@valueFive", SqlDbType.DateTime);
		SqlParameter columnSix = new SqlParameter("@valueSix", SqlDbType.NVarChar);
		SqlParameter columnSeven = new SqlParameter("@valueSeven", SqlDbType.NVarChar);
		columnOne.Value = goodNameForTextBoxOne;
		columnTwo.Value = goodNameForTextBoxFive;
		columnThree.Value = UserName;
		columnFour.Value = "Text";
		columnFive.Value = DateTime.Now;
		columnSix.Value = goodNameForTextBoxThree;
		columnSeven.Value = goodNameForTextBoxTwo;
		SqlCommand cmd = new SqlCommand(query);
		cmd.Parameters.Add(columnOne);
		cmd.Parameters.Add(columnTwo);
		cmd.Parameters.Add(columnThree);
		cmd.Parameters.Add(columnFour);
		cmd.Parameters.Add(columnFive);
		cmd.Parameters.Add(columnSix);
		cmd.Parameters.Add(columnSeven);
		using (SqlConnection connection = new SqlConnection(someConnectionString))
		{
			connection.Open();
			cmd.ExecuteNonQuery();
		}
	}
