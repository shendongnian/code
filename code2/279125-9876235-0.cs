    DataTable RemoveRowsTable = ...;
    int i=0;
    //Remove All
    while (i < RemoveRowsTable.Rows.Count)
    {
         DataRow currentRow = RemoveRowsTable.Rows[i];
         if (currentRow.RowState != DataRowState.Deleted)
         {
             currentRow.Delete();
         }
         else
         {
             i++;
         }
    }
