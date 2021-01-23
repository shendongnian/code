     foreach (DataRow dr in dataTable)
     {
       if (dr.HasErrors)
         {
            Debug.Write("Row ");
            foreach (DataColumn dc in dataTable.PKColumns)
              Debug.Write(dc.ColumnName + ": '" + dr.ItemArray[dc.Ordinal] + "', ");
            Debug.WriteLine(" has error: " + dr.RowError);
         }
      }
