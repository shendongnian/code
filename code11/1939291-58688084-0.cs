    private void Form1_Load(object sender, EventArgs e)
            {
                var select = "SELECT * FROM Product";
    
                var c = new SqlConnection(@""); // Your Connection String here
    
                var dataAdapter = new SqlDataAdapter(select, c);
    
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
    
                dataGridView1.DataSource = ds.Tables[0];
            }
    
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int value =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                SqlConnection connection = new SqlConnection(@""); // Your Connection String here
                connection.Open();
                string sql = string.Format("select SupplierName from Supplier inner join Product On Supplier.NewId = {0}", value);
                SqlCommand command = new SqlCommand(sql,connection);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    textBox1.Text = reader["SupplierName"].ToString();
                }
    
            }
