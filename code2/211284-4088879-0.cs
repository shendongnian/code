    using(var connection = new SqlConnection(myConnectionString))
    using(var adapter = new SqlDataAdapter(mySelectQuery, connection))
    {
       var table = new DataTable();
       adapter.Fill(table);
       this.dataGridView.DataSource = table;
    }
