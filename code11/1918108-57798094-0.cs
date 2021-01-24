     private void DisplayData()  
        {  
            con.Open();  
            DataTable dt=new DataTable();  
            SqlDataAdapter adapt=new SqlDataAdapter("select * from tbl_Record",con);  
            adapt.Fill(dt);  
            dataGridView1.DataSource = dt;  
            con.Close();  
        }  
    private void kaykay_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = 
            "insert into RM_DATA 
           (`Protokol No`,
           `Küpe No`,
           `Cinsi`,
             ...
           '" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayit Basariyla Girildi");
            DisplayData();
        }
