        foreach (string s in textLine)
        {
            try
            {
                DbCommand command2 = db.GetStoredProcCommand("sel_InfoByID_p");
                db2.AddInParameter(command2, "@pGuid", DbType.String, s);
                ds2 = db2.ExecuteDataSet(command2);
             }
            catch (Exception ex)
            {
            }
        }
        
        DataGrid1.DataSource = ds2;
        DataBind();
