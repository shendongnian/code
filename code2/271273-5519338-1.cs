	public static int Insert(string source, string[] column, object[] values)
	{
		int rowsAffected = 0;
		try
		{
			using(SQLiteConnection conn = new SQLiteConnection(connectionString))
			{
				InsertBuilder insertBuilder = new InsertBuilder();
				insertBuilder.TableName = source;
				insertBuilder.Columns = column;
				insertBuilder.Values = values;
				using(SQLiteCommand cmd = new SQLiteCommand(insertBuilder.InsertString, conn))
				{
					for(int i = 0;i < values.Length;i++)
					{
						cmd.Parameters.AddWithValue("@" + values[i].ToString(), values[i]);
					}
					conn.Open();
					rowsAffected = cmd.ExecuteNonQuery();
				}
			}
			return rowsAffected;
		}
		catch(Exception e)
		{
			MessageBox.Show(e.Message);
		}
		return 0;
	}
