    double price= 0;   
    DataTable dt = new DataTable();
    
    string sql = "select total from productADD where auto_no = @auto_no";
    
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    {
    	    SqlCommand command = new SqlCommand(commandText, connection);
            command.Parameters.Add("@auto_no", SqlDbType.Int);
            command.Parameters["@auto_no"].Value = txt_autoNo.Text.Trim();
    }
    
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    
    foreach (DataRow row in dt.Rows)
    {
        float id = (Convert.ToSingle(row["total"]));
        float price = id + price;
        TXT_grandtotal.Text = price
    }
