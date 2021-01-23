protected void Add_Click(object sender, EventArgs e)
{
	string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString;
	using( SqlConnection myConnection = new SqlConnection(strConnectionString) )
	{
		myConnection.Open();
		string hesap = Label1.Text;
		string musteriadi = DropDownList1.SelectedItem.Value;
		string avukat = DropDownList2.SelectedItem.Value;
		string sql = @"INSERT INTO AVUKAT( MUSTERI, AVUKAT, HESAP)
								Select @MUSTERI, @AVUKAT, @HESAP
								From ( Select 1 As Value ) As Z
								Where Not Exists	(
													Select 1
													From AVUKAT As T1
													Where T1.HESAP = @HESAP
													)";
		using ( SqlCommand cmd = new SqlCommand(sql, myConnection) )
		{
			cmd.Parameters.AddWithValue("@HESAP", hesap);
			cmd.Parameters.AddWithValue("@MUSTERI", musteriadi);
			cmd.Parameters.AddWithValue("@AVUKAT", avukat);
			cmd.Connection = myConnection;
			int rowsAffected = cmd.ExecuteNonQuery();
			
			if ( rowsAffected = 0 )
				// tell user that ID exists and their data couldn't be inserted.
			
			Response.Redirect(Request.Url.ToString());
			myConnection.Close();
		}
	}
}
