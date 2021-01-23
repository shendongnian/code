    catDA.UpdateCommand = new OdbcCommand("UPDATE Categories SET CategoryName = ? " +
                                          "WHERE CategoryID = ?" , nwindConn);
    
    catDA.UpdateCommand.Parameters.Add("@CategoryName", OdbcType.VarChar, 15, "CategoryName");
    
    OdbcParameter workParm = catDA.UpdateCommand.Parameters.Add("@CategoryID", OdbcType.Int);
    workParm.SourceColumn = "CategoryID";
    workParm.SourceVersion = DataRowVersion.Original;
    
    DataSet catDS = new DataSet();
    catDA.Fill(catDS, "Categories");    
    
    DataRow cRow = catDS.Tables["Categories"].Rows[0];
    
    cRow["CategoryName"] = "New Category";
    
    DataRow[] modRows = catDS.Tables["Categories"].Select(null, null, DataViewRowState.ModifiedCurrent);
    catDA.Update(modRows);
