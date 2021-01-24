            using(var con = new SqlConnection(...)){
                con.Open();
                string bal = txtBal.Text;
                string sub = txtSub.Text;
                string pay = textBox1.Text;
                sql = "insert into sales(subtoal,pay,bal) values(@subtoal,@pay,@bal); select scope_identity();";
                int lastinsertId = 0;
                using(var cmd = new SqlCommand(sql, con){
                  cmd.Parameters.AddWithValue("@subtoal", sub);
                  cmd.Parameters.AddWithValue("@pay", pay);
                  cmd.Parameters.AddWithValue("@bal", bal);
                  lastinsertID = (int)cmd.ExecuteScalar();               
                }
                string proddname = "";
                int price = 0;
                int qty = 0;
                int tot = 0;
                sql1 = "insert into sales_product(sales_id,prodname,price,qty,total) values(@sales_id,@prodname,@price,@qty,@total)";
                using(var cmd1 = new SqlCommand(sql1, con)){
                  cmd1.Parameters.AddWithValue("@sales_id", lastinsertID);
                  cmd1.Parameters.AddWithValue("@prodname", proddname);
                  cmd1.Parameters.AddWithValue("@price", price);
                  cmd1.Parameters.AddWithValue("@qty", qty);
                  cmd1.Parameters.AddWithValue("@total", total);
                  for (int row = 0; row < dataGridView1.Rows.Count; row++)
                  {
                     proddname = dataGridView1.Rows[row].Cells[0].Value.ToString();
                     price = int.Parse(dataGridView1.Rows[row].Cells[1].Value.ToString());
                     qty = int.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString());
                     int total = int.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());
                     cmd1 = new SqlCommand(sql1, con);
                     cmd1.Parameters["@sales_id"].Value = lastinsertID;
                     cmd1.Parameters["@prodname"].Value = proddname;
                     cmd1.Parameters["@price"].Value = price;
                     cmd1.Parameters["@qty"].Value = qty;
                     cmd1.Parameters["@total"].Value = total;
                     cmd1.ExecuteNonQuery();
                  }
                } //end using sqlcommand
             }//end using sqlconnection - it will close as a result
             MessageBox.Show("Record Addddedddd");
