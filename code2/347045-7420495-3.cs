    if (RadGrid1.SelectedItems.Count > 0)
    {
        //access a string value
        string column1 = RadGrid1.SelectedValues["Column1"].ToString();
        //access an integer value
        int column2 = (int)RadGrid1.SelectedValues["Column2"];
    }
