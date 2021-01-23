    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Page.IsPostBack)
    		return;
    
    	BindDG();
    }
    
    private void BindDG()
    {
    
    	SqlConnection connection = new SqlConnection("Data Source=servername;Initial Catalog=dbname;Integrated Security=True");
    	using (connection)
    	{
    		SqlCommand command = new SqlCommand("select * From staff;",connection);
    		connection.Open();
    
    		SqlDataReader reader = command.ExecuteReader();
    
    		if (reader.HasRows)
    		{
    			DataTable dt = new DataTable();
    			dt.Columns.Add("ID", typeof(int));
    			dt.Columns.Add("Name", typeof(string));
    			dt.Columns.Add("Age", typeof(int));
    
    			while (reader.Read())
    			{
    				int id = (int)reader["id"];
    				string name = reader["name"].ToString();
    				int age = (int)reader["age"];
    
    				dt.Rows.Add(id, name, age);
    			}
    
    			GridView1.DataSource = dt;
    			GridView1.DataBind();
    		}
    		else
    		{
    			Reponse.Write("No records found.");
    		}
    		reader.Close();
    	}
    }
