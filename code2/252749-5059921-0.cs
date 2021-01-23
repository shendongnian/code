    //Create 2-dimensional array with the data from the datatable
    DataTable dt = ds.Tables[0];
    string[,] arrValues = new string[dt.Rows.Count, dt.Columns.Count];
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            arrValues[i, j] = dt.Rows[i].ItemArray[j].ToString();
        }
    }
    
    //Change the data from the column StoryCategoryID here
    //Just loop through the items in the correct column of the array
    //and check whether it's "0" or "1"
    
    //Add headers
    for (int i = 0; i < dt.Columns.Count; i++)
    {
        xlWorkSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
        //Or any name you like 
    }
    
    //Create range (start at row 2 because of header-row)
    Range xlRange = (Range)xlWorkSheet.Cells[2, 1];
    xlRange = xlRange.Resize[dt.Rows.Count, dt.Columns.Count];
    
    //Fill range
    xlRange.Value = arrValues;
    
    //Format document
    xlWorkSheet.EnableAutoFilter = true;
    xlWorkSheet.Cells.AutoFilter(1);
    xlWorkSheet.Range["A1", "A1"].EntireRow.Font.Bold = true;
    xlWorkSheet.Columns.AutoFit();
