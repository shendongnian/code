    private void GetProductMasterDet(string ProductName)  
        {  
            connection();  
            com = new SqlCommand("GetProductDet", con);  
            com.CommandType = CommandType.StoredProcedure;  
            com.Parameters.AddWithValue("@ProductName", ProductName);  
            SqlDataAdapter da = new SqlDataAdapter(com);  
            DataSet ds=new DataSet();  
            da.Fill(ds);  
            DataTable dt = ds.Tables[0];  
            con.Close();  
            //Binding TextBox From dataTable  
            txtbrandName.Text =dt.Rows[0]["BrandName"].ToString();  
            txtwarranty.Text = dt.Rows[0]["warranty"].ToString();  
            txtPrice.Text = dt.Rows[0]["Price"].ToString();   
        }
    
