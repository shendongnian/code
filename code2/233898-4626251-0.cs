    DataSet dataSet = new DataSet("myDataSet");
    dataSet.Tables.Add(new DataTable());
    //Setup the table columns.
    
    foreach (CmsCategory categories in context.spCmsCategoriesReadHierarchy(n,sl,nn))
    {
        DataRow row = dataSet.Tables[0].NewRow();
        row["A"] = categories.A;
        row["B"] = categories.B;
    
        dataSet.Tables[0].Rows.Add(row);
    }
