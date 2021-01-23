    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    { 
    TextBox txtProdID = (TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtProdID");
    TextBox txtProdName = (TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtProdName");
    
    
    //Call update method
    Product.Update(txtProdId,txtProdName);
    
    gvProducts.EditIndex = -1;
    //Refresh the gridviwe
    BindGrid(); 
    }
