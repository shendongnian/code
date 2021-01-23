    conn.Open();
                OleDbCommand cmd2 = new OleDbCommand("SELECT fnID,Lastname,Firstname,Middlename FROM tbl_Fullname WHERE Firstname LIKE '" + textBox3.Text + "%'", conn);
                try
                {
                    OleDbDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();   //fnID
                        textBox2.Text = dr[1].ToString();
                        listBox1.Items.Add(dr[1].ToString()); //Lastname
                        textBox3.Text = dr[2].ToString();   //Firstname
                        textBox4.Text = dr[3].ToString();   //Middlename
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
