    public void IterateRows(Excel.worksheet worksheet)
    {
        //Get the used Range
        Excel.Range usedRange = worksheet.UsedRange;
        
        //Iterate the rows in the used range
        foreach(Excel.Range row in usedRange.Rows)
        {
            //Do something with the row.
        
            //Ex. Iterate through the row's data and put in a string array
            String[] rowData = new String[row.Columns.Count];
            for(int i = 1; i <= row.Columns.Count; i++)
                rowData[i] = row.Cells[1, i].Value2.ToString();
        }
    }
