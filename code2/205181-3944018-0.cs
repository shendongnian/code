		public void Method1()
		{
			using (SqlConnection connection1 = new SqlConnection())
			using (SqlConnection connection2 = new SqlConnection())
			{
			}
		}
		public void Method2()
		{
			using (SqlConnection connection1 = new SqlConnection(), connection2 = new SqlConnection())
			{
			}
		}
