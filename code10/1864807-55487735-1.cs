    protected void txtProductId_TextChanged(object sender, EventArgs e) 
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["_connect"].ToString());
        int ProductId = Convert.ToInt32(txtProductId.Text);
        SqlCommand com = con.CreateCommand();
        com.CommandText = "sp_ProductGetData";
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@Mode", 1);
        com.Parameters.AddWithValue("@ProductId", ProductId);   
            
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            txtProductCategory.Text = Convert.ToString(dr["ProductCategory"]);
            txtProductName.Text = Convert.ToString(dr["ProductName"]);
            txtPrice.Text = Convert.ToString(dr["Price"]);
        }  
        else
        {
            ScriptManager.RegisterClientScriptBlock((Page)(HttpContext.Current.Handler), typeof(Page), "alert", "javascript:alert('" + Convert.ToString(("No Record Found with Prodcut Id: "+ProductId)) + "');", true);
            return;
        }
                    
        con.Close();
    }
