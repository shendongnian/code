        List<MyCustomerClassForTheReturnedValues> values = new List<MyCustomClassForTheReturnedValues>();
        foreach (string s in textLine)
        {
                
                DbCommand command2 = db.GetStoredProcCommand("sel_Guid_p");
                db2.AddInParameter(command2, "@pGuid", DbType.String, s);
                MyCustomClassForTheReturnedValues x = new MyCustomClassForTheReturnedValues(db2.ExecuteDataSet(command2));
                values.Add(x);
        }
        DataGrid1.DataSource = values;
        DataGrid1.DataBind();
