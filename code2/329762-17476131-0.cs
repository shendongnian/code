     public static void KillPrimaryKey(DataTable LocDataTable)
    {
      int LocPriKeyCount = LocDataTable.PrimaryKey.Length;
      string[] PrevPriColumns = new string[LocPriKeyCount];
      // 1. Store ColumnNames in a string Array
      for (int ii = 0; ii < LocPriKeyCount; ii++) PrevPriColumns[ii] = LocDataTable.PrimaryKey[ii].ColumnName;
      // 2. Clear PrimaryKey
      LocDataTable.PrimaryKey = null;
      // 3. Clear Unique settings
      for (int ii = 0; ii < LocPriKeyCount; ii++) LocDataTable.Columns[PrevPriColumns[ii]].Unique = false;
    }
