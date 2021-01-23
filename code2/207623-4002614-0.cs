            Form1()
            {
                InitializeComponent();
                openFileDialog1.ShowDialog();
                openedFile = openFileDialog1.FileName;
                // Assuming your "lbxEmployeeNames" is a DataGridView or alike.
                lbxEmployeeNames.DataSource = Query("Select [name] FROM [Employees$]");
            }
    
  
            // Return a DataTable instead of String.
            public DataTable Query(string sql)
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                
                string connectionPath;
    
                //build connection string
                connectionPath = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + openedFile + "';Extended Properties=Excel 8.0;";
    
                MyConnection = new System.Data.OleDb.OleDbConnection(connectionPath);
                MyConnection.Open();
                System.Data.OleDb.OleDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter(sql, MyConnection);
                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);
                return dt;
            }
