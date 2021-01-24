    private void Form1_Load(object sender, EventArgs e)
    {
        String query = "INSERT INTO STOCK_IN(SIN_No., PO_NO., Product_ID, Received_Date, Quantity) VALUES (@val1, @val2, @val3, @val4, @val5)";
        SqlDataAdapter sda = new SqlDataAdapter();
        try
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.Parameters.Add("@val1", SqlDbType.VarChar).Value = textBox1.Text;
                //Then the same for 2, 3, 4, 5
                sda = cmd.ExecuteNonQuery();
            }
        }
        catch (SqlException ex) 
        {
             Console.WriteLine(ex.Message); 
        }
        finally 
        { 
             con.Close(); 
             MessageBox.Show("DATA INSERTED SUCCESSFULLY"); 
        }
    }
