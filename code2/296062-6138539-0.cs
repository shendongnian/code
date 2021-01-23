    private void Update_Record_Click(object sender, EventArgs e)  
    {  
        if (textBox4.Text == "" && textBox2.Text == "")
        {
            MessageBox.Show("No value entered for update.");  
            return;
        }
    	ConnectionClass.OpenConnection();  
    
        var cmd = new SqlCommand("update medicinerecord set quantity='" + textBox2.Text + "' where productid='" + comboBox1.Text + "'", ConnectionClass.OpenConnection());
        cmd.ExecuteNonQuery();  
    
    	cmd = null;
        if (textBox2.Text != "")
            cmd = new SqlCommand("update myrecord set quantity='" + textBox2.Text + "' where productid='" + comboBox1.Text + "'", ConnectionClass.OpenConnection());
        else if (textBox4.Text != "")
            cmd = new SqlCommand("update myrecord set price='" + textBox4.Text + "' where productid='" + comboBox1.Text + "'", ConnectionClass.OpenConnection());
    
        if (cmd != null) cmd.ExecuteNonQuery();
        ConnectionClass.CloseConnection();
    }  
