	using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessDB"].ConnectionString))
	using (OleDbCommand command = new OleDbCommand())
	{
		command.Connection = connection;
		//                                                 1st                   2nd               3rd                4th                   5th
		command.CommandText = "Update  Party  Set  Address=@address, PhoneNumber=@phone, FaxNumber=@fax, UniqueNumber=@unique WHERE PartyID=@id";
		command.Parameters.AddWithValue("@address", this.address); // 1st
		command.Parameters.AddWithValue("@phone", this.phoneNumber); // 2nd
		if (string.IsNullOrEmpty(faxNumber))
		{
			faxNumber = string.Empty;
		}
		command.Parameters.AddWithValue("@fax", this.faxNumber); // 3rd
		command.Parameters.AddWithValue("@unique", this.uniqueNumber); //4th
		command.Parameters.AddWithValue("@id", this.partyID); // 5th
		connection.Open();
		command.ExecuteNonQuery();
	}
