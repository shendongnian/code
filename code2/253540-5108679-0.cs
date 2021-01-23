try
{
	string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString;
	SqlConnection myConnection = new SqlConnection(strConnectionString);
	myConnection.Open();
	string hesap = Label1.Text;
	string musteriadi = DropDownList1.SelectedItem.Value;
	string avukat = DropDownList2.SelectedItem.Value;
	SqlCommand cmd = new SqlCommand("INSERT INTO AVUKAT VALUES (@MUSTERI, @AVUKAT, @HESAP)", myConnection);
	cmd.Parameters.AddWithValue("@HESAP", hesap);
	cmd.Parameters.AddWithValue("@MUSTERI", musteriadi);
	cmd.Parameters.AddWithValue("@AVUKAT", avukat);
	cmd.Connection = myConnection;
	SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	Response.Redirect(Request.Url.ToString());
	myConnection.Close();
}
catch (SqlException ex)
{
	if (ex.Number == 2627)
	{
		// Add a javascript alert to let the user know that the same HESAP value already exists.
	}
	else
	{
		// Rethrow the exception.
		throw;
	}
}
