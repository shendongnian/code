          private void Select()
           {
                  string query = "SELECT * FROM Bill";
            
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, DBconn);
            
                    OleDbCommandBuilder cBuilder = new OleDbCommandBuilder(dAdapter);
            
                    DataTable dTable = new DataTable();
            
                    dAdapter.Fill(dTable);
            
                    //BindingSource to sync DataTable and DataGridView
                    BindingSource bSource = new BindingSource();
            
                    //set the BindingSource DataSource
                    bSource.DataSource = dTable;
            
                    //set the DataGridView DataSource
                    dataGridViewX1.DataSource = bSource;
            
                    dAdapter.Update(dTable);
            
            
                }
            
                private void buttonX1_Click(object sender, EventArgs e)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Bill (Item, Quantity, Price) VALUES ('Soft Drink', 1, 1)";
                    cmd.Connection = DBconn;
                    DBconn.Open();
                    cmd.ExecuteNonQuery();
                    DBconn.Close();
    
    //call the Select function
    
                      Select();
                }
