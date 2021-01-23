    protected void rptrMainCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType== ListItemType.Item)
        {
            int subCategoryID = 5; // Pass your subcategory id to be filtered
            Repeater rptrSubCategories = (Repeater)e.Item.FindControl("rptrSubCategories");
            DataTable dtSubCategory = new DataTable();
            dtSubCategory.Columns.Add(); // Add your columns as SubCatagory
            DataRow[] dataRows = dataTableCategories.Select("SubCategoryID= " + subCategoryID + "");
            foreach (DataRow dataRow in dataRows)
            {
                dtSubCategory.ImportRow(dataRow);
            }
            rptrSubCategories.DataSource = dtSubCategory;
            rptrSubCategories.DataBind();
        }
    }
    protected void rptrSubCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType== ListItemType.Item)
        {
            int subSubCategoryID = 55; // Pass your subsubcategory id to be filtered
            Repeater rptrSubSubCategory = (Repeater)e.Item.FindControl("rptrSubSubCategory");
            DataTable dtSubSubCategory = new DataTable();
            dtSubSubCategory.Columns.Add(); // Add your columns as SubCatagory
            DataRow[] dataRows = dataTableCategories.Select("SubSubCategoryID= " + subSubCategoryID + "");
            foreach (DataRow dataRow in dataRows)
            {
                dtSubSubCategory.ImportRow(dataRow);
            }
            rptrSubSubCategory.DataSource = dtSubSubCategory;
            rptrSubSubCategory.DataBind();
        }
    }
