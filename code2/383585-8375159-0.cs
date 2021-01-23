    public DataTable GetData()
    {
        string connectionString = "Your connection string";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM YourTableName", connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable table = new DataTable();
        adapter.Fill(table);
        connection.Close();
        return table;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        gridView.DataSource = GetData();
        gridView.DataBind();
    }
