 C#
[System.Web.Services.WebMethod]
public static string GetDateFromDB(DateTime compareDate)
{      
	string selectedDate = compareDate.ToString("yyyy/MM/dd");   
	SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginDBConnectionString1"].ConnectionString);
	SqlCommand com = new SqlCommand("SELECT * from Holiday", conn);
	SqlDataAdapter sqlDa = new SqlDataAdapter(com);
	DataTable dt = new DataTable();
	sqlDa.Fill(dt);
	if (dt != null && dt.Rows.Count > 0)
	{
		string formatDate = "yyyy/MM/dd";
		foreach (DataRow dr in dt.Rows)
		{
			string dateString = dr["yourColumnName"].ToString();
			if (string.IsNullOrEmpty(dateString))
			{
				continue; // Or set error or something
			}
			dateString = DateTime.ParseExact(dateString.Split(' ')[0], formatDate, null).ToString(formatDate);
			if (dateString.Equals(compareDate))
			{
				// Do something
			}
			else
			{
				// Set error message or something
			}
		}
		// Check after loop and return "OK" or "NG"
	}     
}
