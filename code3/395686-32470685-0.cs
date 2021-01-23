    foreach (DataRow inRow in inputTable.Rows)
         {
             string newColName = inRow[0].ToString();
             outputTable.Columns.Add(newColName);
         }
