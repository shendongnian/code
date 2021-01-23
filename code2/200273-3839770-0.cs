			List<String> values = new List<String>();
			using(SqlCommand objCommand = new SqlCommand("SELECT field1, field2 FROM sourcetable", objConn)) {
				using(SqlDataReader objDataReader = objCommand.ExecuteReader()) {
					while(objDataReader.Read()) {
						values.Add(objDataReader[0].ToString());
					}
				}
			}
			foreach(String value in values) {
				using(SqlCommand objInsertCommand = new SqlCommand("INSERT INTO tablename (field1, field2) VALUES (3, '" + value + "')", objConn)) {
					objInsertCommand.ExecuteNonQuery();
				}
			}
