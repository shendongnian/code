    protected void btn_Click(object sender, EventArgs e)
    {
        string Name = textbox.Text;
        
        // you update with the new parametre
        CategoryAccess.UpdateProducts(Name);
    
        // you get the new data
        DataTable table = CategoryAccess.GetProducts();
    
        // and show it
        ProductList.DataSource = table;
        ProductList.DataBind();
    }
