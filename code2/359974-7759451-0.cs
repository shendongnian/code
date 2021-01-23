		public void foo(string connectionString, string textToSave)
		{
			var cmdString = "insert into tbl_articles (text) values (@text)";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand(cmdString, conn))
				{
					comm.Parameters.Add("@text", SqlDbType.VarChar, -1).Value = textToSave;
					comm.ExecuteNonQuery();
				}
			}
		}
