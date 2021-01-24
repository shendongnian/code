    Label l1 = g1.Rows[e.RowIndex].FindControl("idlbl") as Label;
    TextBox t1 = g1.Rows[e.RowIndex].FindControl("typeText") as TextBox;
    
    string orderType = t1.Text;
    string order_id = l1.Text;
    string Query = "update app_order_master set order_amt = @orderType where order_id = @order_id";
    MySqlCommand cmd = new MySqlCommand(Query);      
    cmd.Parameters.Add("@orderType", orderType);      
    cmd.Parameters.Add("@order_id", order_id);     
    cmd.Connection = sqlconn;
    cmd.ExecuteNonQuery();
