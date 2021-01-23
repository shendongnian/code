    DataTable obj_Tb=new DataTable();
      obj_Tb.Columns.Add("ColumnName");
       .  //Add Columns as your requirement
       .
       .
    
    foreach (string s in textLine)
            {
                try
                {
                    DataRow objrow=obj_Tb.NewRow();
                    DbCommand command2 = db.GetStoredProcCommand("sel_InfoByID_p");
                    db2.AddInParameter(command2, "@pGuid", DbType.String, s);
                    ds2= db2.ExecuteDataSet(command2);
              objrow["ColumnName"]=ds2.Table[0].Rows[RowNumber]["ColumnName"].tostring();
                    //Add Values to all columns as requirement
                    obj_Tb.Rows.Add(objrow);
                    
                 }
    
                catch (Exception ex)
                {
    
                }
    }
                  DataGrid1.DataSource = obj_Tb;
                  DataGrid1.DataBind();
