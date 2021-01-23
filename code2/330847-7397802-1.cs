    try
    {
        OpenOleDBConnection();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from [" + SelectedSheet + "]", Connection);
        dataAdapter.Fill(DataTable);
        if ((DataTable != null) && (DataTable.Rows != null) && (DataTable.Rows.Count > 0))
        {
            List<System.Data.DataRow> removeRowIndex = new List<System.Data.DataRow>();
            int RowCounter = 0;
            foreach (System.Data.DataRow dRow in DataTable.Rows)
            {                            
                for(int index = 0; index < DataTable.Columns.Count; index++)
                {
                    if (dRow[index] == DBNull.Value)  
                    {
                        removeRowIndex.Add(dRow);
                        break;
                    }
                    else if (string.IsNullOrEmpty(dRow[index].ToString().Trim()))
                    {
                        removeRowIndex.Add(dRow);
                        break;
                    }
                }
                RowCounter++;
            }
            // Remove all blank of in-valid rows
            foreach (System.Data.DataRow rowIndex in removeRowIndex)
            {
                DataTable.Rows.Remove(rowIndex);
            }
        }
    }
    catch(Exception e)
    {
        WPFMessageBox.Show(e.Message, Globalization.GetValue("Import_ImportOption_FormHeader"), WPFMessageBoxButtons.OK, WPFMessageBoxImage.Error);
    }
    finally
    {
        CloseOleDBConnection();
    }
