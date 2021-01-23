    private void GetData(...)
    {
        // Call SELECT statements to fill a dataset with two tables
        DataSet set = new DataSet();
        ....
        // set now contains tables[0] (for the data) and tables[1] (for the Rate).
        // Get the Rate
        int rate = (int)set.Tables[1].Rows[0]["Rate"]; // Assuming that the column is named "Rate"
        // Now iterate over all data rows and calculate amount
        foreach (DataRow row in set.Tables[0])
        {
            row["Amount"] = ((int)row["Total"] * rate);
        }
        // Mark the data set as unmodified
        set.AcceptChanges();
    }
