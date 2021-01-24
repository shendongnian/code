    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HtmlInputText txtname = (HtmlInputText)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
    
        string id= GridView1.DataKeys[e.RowIndex].Values[0].ToString(); //Here You will Get DataKeys..
        
        SqlConnection conn = new SqlConnection("");//Put Your Sql connection
        SqlDataAdapter da = new SqlDataAdapter("", conn);
        conn.Open();
        da.UpdateCommand = new SqlCommand("update dbo.[2KEE_RAW] set comment='" + txtname.Value + "' where id='" + product_id + "' and price_id='" + id + "'", conn);
        da.UpdateCommand.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        bindgrid(); // Again bind the Same gridview
    }
