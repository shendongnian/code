    [WebMethod]
	public int GetUCount(string invoicenumberhidden)
    {		
		if (String.IsNullOrEmpty(invoicenumberhidden))
		{
			return 999999999;
		}
		else 
		{ 
			int invoicenumber = int.Parse(invoicenumberhidden);
			string commandText = "SELECT COUNT(*) AS distinct_count FROM (SELECT DISTINCT [inv_section],[invoice_number], [cust_po] FROM [Indigo].[dbo].[invoice_items] WHERE invoice_number=" + invoicenumber + ") AS I;";
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Indigo2.Properties.Settings.Constr"].ConnectionString;
				using (SqlConnection conn = new SqlConnection(connectionString))
				using (SqlCommand cmd = new SqlCommand(commandText, conn))
				{
					conn.Open();
					cmd.ExecuteNonQuery();
					int uniquecount = (Int32)cmd.ExecuteScalar();
					conn.Close();
					return uniquecount;
				}
		}          		
	}
	
	
