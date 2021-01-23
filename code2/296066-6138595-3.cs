	if (!HasPriceValue() && !HasQuantityValue())
	{ 
	    MessageBox.Show("No value entred for update."); 
	}
	else
	{
		ConnectionClass.OpenConnection(); 
		if (HasQuantityValue())  
		{  
			SqlCommand cmd = new SqlCommand("update medicinerecord set quantity='" + textBox2.Text + "' where productid='"+comboBox1.Text+"'", ConnectionClass.OpenConnection());  
			cmd.ExecuteNonQuery();  
		}
		if (HasPriceValue())
		{
			SqlCommand cmd = new SqlCommand("update myrecord set price='" + textBox4.Text + "' where productid='" + comboBox1.Text + "'", ConnectionClass.OpenConnection());
			cmd.ExecuteNonQuery();
		}
		ConnectionClass.CloseConnection();
	}
