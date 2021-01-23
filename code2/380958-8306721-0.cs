    DataTable table = new DataTable("MyDataTable");
    using (SqlConnection connection = new SqlConnection(YourDBConnectionString))
    {
        string sqlText = "SELECT * FROM " + txtTableName.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);
        adapter.SelectCommand.CommandType = CommandType.Text;
        connection.Open();
        adapter.Fill(table);
    }
    gridViewData.DataSource = table;
    gridViewData.DataBind();
