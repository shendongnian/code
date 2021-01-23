        int rowCount = range.Rows.Count;
        int colCount = range.Columns.Count;
        object[,] = range.Value2;
        int rowCounter = 1;
        int colCounter = 1;
        while (rowCounter < rowCount)
        {
            colCounter = 1;
            while (colCounter <= colCount)
            {
                // check for null?
                testList.Add(values[rowCounter, colCounter].ToString());
            }
        }
