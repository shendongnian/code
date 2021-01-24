    private void cashReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
	{
		lblTyp = "CR -";
		sqlConn = new SqlConnection(connstring);
		string typ = "NCR";
		string QMonth1 = @"SELECT * FROM av WHERE vtype =@vtype";
		SqlCommand SqlCmd1 = new SqlCommand(QMonth1, sqlConn);
		try
		{
			sqlConn.Open();
			SqlCmd = new SqlCommand(@"SELECT MONTH(CURRENT_TIMESTAMP) ", sqlConn);
			var month = (int)SqlCmd.ExecuteScalar();
			string QMonth = $"M{month}";
			// adding parameter to sql query
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@vtype";
			param.Value = typ;
			SqlCmd1.Parameters.Add(param);
			dataReader = SqlCmd1.ExecuteReader();
			while (dataReader.Read())
			{
				var vtype = dataReader["vtype"] as string;
				var Mon1 = dataReader["M1"] as string;
				var Mon2 = dataReader["M2"] as string;
				var Mon3 = dataReader["M3"] as string;
				var Mon4 = dataReader["M4"] as string;
				var Mon5 = dataReader["M5"] as string;
				var Mon6 = dataReader["M6"] as string;
				Vno = Mon4;
			}
		}
		catch (SqlException ex)
		{
			MessageBox.Show(ex.Message);
		}
		DataEntryVType.ShowDialog();
	}
