    for (int i = rowToRemove.Count - 1; i >= 0; i--)
    {
       dsExcel.Tables[0].Rows.RemoveAt(rowToRemove[i]);
           //dsExcel.Tables[0].Rows.Remove(rowNumber); ; ;
    }
