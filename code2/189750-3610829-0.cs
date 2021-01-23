	foreach (string ri in temp1)
	{
		for (int index = 0; index < ssl.Count; index++)
		{
			try
			{
				SqlCommand command;
				string query;
				query = string.Format("select count(*) from sample s inner join   sample ss on ss.KeyWord='{0}' and ss.{1}=0 and s.KeyWord='y' and s.{1}=0", ri, ssl[index].ToString());
				command = new SqlCommand(query, con);
				if ((int)command.ExecuteScalar() == 1)
				{
					gh++;
					gh3++;
				}
				query = string.Format("select count(*) from sample s inner join   sample ss on ss.KeyWord='{0}' and ss.{1}=0 and s.KeyWord='y' and s.{1}>0", ri, ssl[index].ToString());
				command = new SqlCommand(query, con);
				if ((int)command.ExecuteScalar() == 1)
				{
					gh2++;
					gh4++;
				}
				if (index == (ssl.Count-1))
				{
					query = string.Format("update sample set N00={0} where KeyWord='{1}'", gh.ToString(), ri);
					command = new SqlCommand(query, con);
					command.ExecuteNonQuery();
					gh = 0;
					query = string.Format("update sample set N01={0} where KeyWord='{1}'", gh2.ToString(), ri);
					command = new SqlCommand(query, con);
					command.ExecuteNonQuery();
					gh2 = 0;
					query = string.Format("update sample set N10={0} where KeyWord='{1}'", gh3.ToString(), ri);
					command = new SqlCommand(query, con);
					command.ExecuteNonQuery();
					gh3 = 0;
					query = string.Format("update sample set N11={0} where KeyWord='{1}'", gh4.ToString(), ri);
					command = new SqlCommand(query, con);
					command.ExecuteNonQuery();
					gh4 = 0;
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.Print(ex.ToString());
			}
		}
	}
	SqlCommand command = new SqlCommand("select KeyWord from sample", con);
	SqlDataAdapter da = new SqlDataAdapter(command);
	DataSet ds = new DataSet();
	da.Fill(ds, "sample");
	foreach (DataRow dr in ds.Tables[0].Rows)
	{
		string KeywordCell = dr["KeyWord"].ToString();
		if (KeywordCell != "y")
		{
			if (!li.Contains(KeywordCell))
			{
				li.Add(KeywordCell);
			}
		}
	}
