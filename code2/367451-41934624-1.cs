    int countRow = dt.Rows.Count;
    int countCol = dt.Columns.Count;
    for (int iCol = 0; iCol < countCol; iCol++)
    {
         DataColumn col = dt.Columns[iCol];
         for (int iRow = 0; iRow < countRow; iRow++)
         {
             object cell = dt.Rows[iRow].ItemArray[iCol];
         }
    }
