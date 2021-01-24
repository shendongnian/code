     public DataTable Table()
        {
            try
            {
                connectionString = "Data Source = Your Data source ";
                connection = new SQLiteConnection(connectionString);
                query = "SELECT * From Table";
                connection.Open();
                adapter = new SQLiteDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                return dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        private void FillDataGrid()
        {
            dataTable = Table();
            dataGridView.DataSource = dataTable;
        }
