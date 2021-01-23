    private IEnumerable<string> Getcategories()
    {
        return categproes.Select(c=>c.category_Name);
    }
    
    private void BindCategories()
    {
        categoryCombobox.DataSource = this.GetCategories();
        categoryCombobox.DataBind();
    }
    
    private void categoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCategories();
    } 
