		protected void cvalDOB_ServerValidate(object sender, ServerValidateEventArgs e)
		{
			e.IsValid = IsValidSqlDateTime(e.Value);
		}
		public static bool IsValidSqlDateTime(object Date)
		{
			try
			{
				System.Data.SqlTypes.SqlDateTime.Parse(Date.ToString());
				return true;
			}
			catch
			{
				return false;
			}
		}
