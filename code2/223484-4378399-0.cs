    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection("Data Source=.; Integrated Security=SSPI; Initial Catalog=FA");
    
    
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;
            c.Open();
    
            // get remaining stocks
            cmd.CommandText = "SELECT Qty from TEST WHERE Id=1";
            int ret = Convert.ToInt32(cmd.ExecuteScalar().ToString());
    
            if (ret == 0)
            {
                Label1.Text = "Not enough stocks.";
            }
            else 
            {
                cmd.CommandText = "UPDATE TEST SET Qty = Qty-1 WHERE Id=1";
                cmd.ExecuteNonQuery();
    
                if (ret == 2)
                {
                    Label1.Text = "Re-order. Remaining stocks: 1";
                }
                else
                {
                    Label1.Text = "Remaining stocks: " + (ret-1).ToString();
                }
            }
    
    
            c.Close();
        }
