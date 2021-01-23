    try
    {
        myDataSet = new DataSet();
        myDataSet.CaseSensitive = true;
        DataAdapter.SelectCommand.Connection = myConnection;
        DataAdapter.TableMappings.Clear();
        DataAdapter.TableMappings.Add("Table", "TableName");
        DataAdapter.Fill(myDataSet);
        myDataView = new DataView(myDataSet.Tables["TableName"], "TIMESTAMP >= '" + 
        Convert.ToDateTime(fromDate) + "' AND TIMESTAMP <= '" + 
        Convert.ToDateTime(toDate) + "'", "TIMESTAMP", DataViewRowState.CurrentRows);
        dgv.DataSource = myDataView;
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
