protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
{
	int avukat;
	int hesapNo;
	bool enabled = int.TryParse( DropDownList1.SelectedItem.Value, out hesapNo ) 
		&& int.TryParse( DropDownList2.SelectedItem.Value, out avukat ) 
		&& hesapNo != 0 
		&& avukat != 0;
		
	if ( enabled )
	{
		string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString;
		
		using( SqlConnection myConnection = new SqlConnection(strConnectionString) )
		{
			myConnection.Open();
			string query = @"Select A.HESAP_NO 
						     From YAZ..MARDATA.S_TEKLIF A 
						     Where A.MUS_K_ISIM = @HesapNo"
			
			using( SqlCommand cmd = new SqlCommand(query, myConnection) )
			{
				cmd.AddParameterWithValue( "@HesapNo", hesapNo );
				Label1.Text = cmd.ExecuteScalar().ToString();
			}
		}
	}
	
	Add.Enabled = enabled;
	Label1.Visible = false;
}
