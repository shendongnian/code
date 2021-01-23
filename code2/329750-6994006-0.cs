    for (int i = 0; i < rowToRemove.Count; i++)
    {
       **dsExcel.Tables[0].Rows.RemoveAt(rowToRemove[i]);**
       //dsExcel.Tables[0].Rows.Remove(rowNumber); ; ;
    }
