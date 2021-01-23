    public void BulkExportToAccess(DataTable dtOutData, String DBPath, String TableNm) 
    {
      DAO.DBEngine dbEngine = new DAO.DBEngine();
      Boolean CheckFl = false;
      try
      {
	  #region Dao
	  DAO.Database db = dbEngine.OpenDatabase(DBPath);
	  DAO.Recordset AccesssRecordset = db.OpenRecordset(TableNm);
	  DAO.Field[] AccesssFields = new DAO.Field[dtOutData.Rows.Count];
	  //Loop on each row of dtOutData
	  for (Int32 rowCounter = 0; rowCounter < dtOutData.Rows.Count; rowCounter++)
	  {
		  AccesssRecordset.AddNew();
		  //Loop on column
		  for (Int32 colCounter = 0; colCounter < dtOutData.Columns.Count; colCounter++)
		  {
			 // for the first time... setup the field name.
			  if (!CheckFl) { AccesssFields[colCounter] = AccesssRecordset.Fields[dtOutData.Columns[colCounter].ColumnName]; }
			  AccesssFields[colCounter].Value = dtOutData.Rows[rowCounter][colCounter];
		  }
		  AccesssRecordset.Update();
		  CheckFl = true;
	  }
	  AccesssRecordset.Close();
	  db.Close();
	 
	  #endregion
    }
    catch (Exception ex)
    {
	  throw ex;
    }
    finally
    {
	  System.Runtime.InteropServices.Marshal.ReleaseComObject(dbEngine);
	  dbEngine = null;
    }
    }
