    private void AddAllRequiredItems_Click(object sender, EventArgs e)
    {
        var stockItems = new List<MyData>();
        RequiredStockForAllOrders(stockItems);
        string sql2 = "INSERT INTO restockingDetails(RestockingID,ProductID,Quantity,Shop_ID) values (@restockingID,@productID,@quantity,@shop_id)";
        using(OleDbConnection con = new OleDbConnection(DatabaseConnectionString))
        using(OleDbCommand cmd = new OleDbCommand(sql2, con))
        {
            con.Open();
            cmd.Parameters.Add("@restockingID", OleDbType.Integer);
            cmd.Parameters.Add("@productID", OleDbType.Integer);
            cmd.Parameters.Add("@quantity", OleDbType.Integer);
            cmd.Parameters.Add("@shop_id", OleDbType.Integer);
            foreach(MyData item in stockItems)
            {
               try
               {
                   cmd.Parameters["@restockingID"].Value = restockingOrder;
                   cmd.Parameters["@productID"].Value = item.productId;
                   cmd.Parameters["@quantity"].Value = item.productQuantity;
                   cmd.Parameters["@shop_id"].Value = shopIDGlobal;
                   cmd.ExecuteNonQuery();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
          }
       }
    }
