	List<string> namesCollection = new List<string>();
	SqlConnection conn = new SqlConnection();
	conn.ConnectionString = 'Connexion String or From File'
	SqlCommand cmd = new SqlCommand();
	cmd.Connection = conn;
	cmd.CommandType = CommandType.Text;
	cmd.CommandText = "Select distinct [Name] from [Names] order by [Name] asc";
	conn.Open();
	SqlDataReader dReader = cmd.ExecuteReader();
	if (dReader.HasRows == true)
	{
	   while (dReader.Read())
	   namesCollection.Add(dReader["Name"].ToString());
	}
	dReader.Close();
	txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
	txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
	txtName.AutoCompleteCustomSource = namesCollection;
