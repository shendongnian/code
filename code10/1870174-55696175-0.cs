	var idToDelete = int.Parse(txtImgID.Text); // this is not necessary if the data type in the DB is actually a string
	
	using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GMSConnectionString"].ConnectionString))
	using (SqlCommand cmd = new SqlCommand("DELETE FROM [certf] WHERE id = @id", con))
	{
	  // I am assuming that id is an integer but if it is a varchar/string then use the line below this one
	  // cmd.Parameters.Add("@id", SqlDbType.VarChar, 100).Value = txtImgID.Text;
	  cmd.Parameters.Add("@id", SqlDbType.Int32).Value = idToDelete;
	  cmd.ExecuteNonQuery();
	}
