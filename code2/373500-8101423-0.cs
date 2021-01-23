    GetCustomers(textBox1.Text);
    
    
    // Load Data from the DataSet into the DataGridView
    private void GetCustomers(string searchTerm)
    {
    DataSet dataset = new DataSet();
    using (OleDbConnection connection = 
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccess2007file.accdb;Persist Security Info=False;"))
      {
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = new OleDbCommand(
            "select * from customer where name like %" + searchTerm + "%", connection);
        adapter.Fill(dataset, "Customers");
      }
    
        // Get the table from the data set and bind the data to the grid
        DataGridView.DataSource = dataset.Tables[0];
    }
