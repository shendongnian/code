    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string product_id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string price_id = GridView1.DataKeys[e.RowIndex].Values[1].ToString();
        string value = GridView1.DataKeys[e.RowIndex].Values[2].ToString(); //Here you will get the datakeys value 
        SqlConnection conn = new SqlConnection("");//Put Your Sql connection
        SqlDataAdapter da = new SqlDataAdapter("", conn);
        conn.Open();
        da.UpdateCommand = new SqlCommand("update YourTableName set value='" + value + "' where product_id='" + product_id + "' and price_id='" + price_id + "'", conn);
        da.UpdateCommand.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        bindgrid(); // Again bind the Same gridview
    }
