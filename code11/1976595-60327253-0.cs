private void RegisterForm_Load(object sender, EventArgs e)
{
	HideMe();
	MoveMe(-180);
	using(MySqlConnection myConnection = new MySqlConnection(conString)){
		myConnection.Open();
		MySqlCommand myCommand = new MySqlCommand("GetRaceLevels", myConnection); 
		myCommand.CommandType = CommandType.StoredProcedure;
		using(MySqlDataReader DataReader = myCommand.ExecuteReader()){
			try
			{
				while (DataReader.Read())
				{
					cboRunnerTypes.Items.Add(DataReader[1]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Critical error!");
			}
		}				
	}
}
