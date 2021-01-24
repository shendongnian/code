        OleDbConnection con = new OleDbConnection(DatabaseConnectionString);
        OleDbCommand cmd;
        string sql2 = "INSERT INTO restockingDetails(RestockingID,ProductID,Quantity,Shop_ID) values (@restockingID,@productID,@quantity,@shop_id)";
        
        int i = 0;
        while (i < stockItems.Count)
        {
            try
            {
                MessageBox.Show(stockItems[i].productId.ToString()); //For testing
                
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@restockingID", restockingOrder);
                cmd.Parameters.AddWithValue("@productID", stockItems[i].productId);
                cmd.Parameters.AddWithValue("@quantity", stockItems[i].productQuantity);
                cmd.Parameters.AddWithValue("@shop_id", shopIDGlobal);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Item added to list"); //for testing
                con.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            i = i + 1;
        }
