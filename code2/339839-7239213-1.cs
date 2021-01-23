    public static DataTable GetProductList()
    {
        DatabaseAdapter dba = DatabaseAdapter.GetInstance();
        // Return a second, aliased column that concatenates PRODUCT_ID
        // with " - " and DESCRIPTION (alias NEW_DESCRIPTION)
        string sqlQuery = ("SELECT PRODUCT_ID, PRODUCT_ID + " - " + DESCRIPTION AS NEW_DESCRIPTION FROM PRODUCT");
        DataTable dt = new DataTable();
        dt.Load(dba.QueryDatabase(sqlQuery));
        return dt;
    }
    private void PopulateProductList()
    {
        try
        {
            ProductList.DataSource = BusinessLayerHandler.GetUnitList();
            // Assign the NEW_DESCRIPTION column to the DataTextField
            ProductList.DataTextField = "NEW_DESCRIPTION";
            ProductList.DataValueField = "PRODUCT_ID";
            ProductList.DataBind();
        }
        catch
        {
            new Logging("E00080002");
            Alert("Failed to Import Product List");
        }
    }
