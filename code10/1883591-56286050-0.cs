      private void frmRepoPremier_Load(object sender, EventArgs e)
            {
                DataSet ds = new DataSet();
                string query = "select * from Repos";
    
                try
                {
                    MySqlConnection sqlConnection = new MySqlConnection(MyConnectionString);
                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(ds);
                    sqlConnection.Close();
                    dgvBuildings.DataSource = ds.Tables[0];
    
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dgvBuildings.Columns.Add(btn);
                    btn.HeaderText = "Photos";
                    btn.Text = "View";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;
                   //HID THIS COLUMN TO REPLACE THE VIEW BUTTON
                    this.dgvBuildings.Columns[11].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error: Load Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    { connection.Close(); }
    
                }
            }
    
            private void dgvBuildings_CellClick(object sender, DataGridViewCellEventArgs e)
            { var senderGrid = (DataGridView)sender;
              if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
              { 
              //OPEN IMAGE FROM BUTTON
              System.Diagnostics.Process.Start(textBox1.Text);
              }
                
            }
    
            private void dgvBuildings_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvBuildings.Rows[e.RowIndex];
                    textBox1.Text = row.Cells[12].Value.ToString();
    
                    try
                    {
                        if (row.Cells[12].Value != null)
    
                        { pictureBox1.LoadAsync(row.Cells[12].Value.ToString()); }
                        else
                        { return; }
                    }
                    catch (Exception)
                    {
                        pictureBox1.Image = null;
                        return;
                    }
    
                }
            }
