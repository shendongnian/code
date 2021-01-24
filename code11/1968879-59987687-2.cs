	public static IEnumerable<FileInfo> ReturnFileFromDBInfo()
	{
		var result = new List<FileInfo>();
		using (SqlConnection conn = new SqlConnection())
		{
			conn.ConnectionString = @"data source = MYPC\SQLEXPRESS; database = MYDB; integrated security = TRUE";
			conn.Open();
			var query = "SELECT a.partNumber, b.fullPath,a.fileType,a.baseID FROM drawings a ,bases_bases b WHERE a.baseID = b.id";
			using (var cmd = new SqlCommand(query, conn))
			using (SqlDataReader dataReader = cmd.ExecuteReader())
			{
				while (dataReader.Read())
				{
				   yield return new FileInfo()
				   {
					   partNumber = dataReader["partNumber"].ToString(),
					   path = dataReader["fullPath"].ToString(),
					   fileType = dataReader["fileType"].ToString(),
					   baseID = dataReader["baseID"].ToString(),
				   };
				}
			}
		}
	}
