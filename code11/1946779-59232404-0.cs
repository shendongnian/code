           private void AddNewRow(string s, string s1, int ClasaMesaj)
    {
        int rowIndex = 1;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        DataRow drCurrentRow = dtCurrentTable.NewRow(); // null;// 
     dtCurrentTable.NewRow();
        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        {
            drCurrentRow["RowNumber"] = i+1;
            drCurrentRow[1] = s;// "s";
            drCurrentRow[2] = s1;// "s1";
            drCurrentRow[3] = ClasaMesaj;
            rowIndex++;
        }
        dtCurrentTable.Rows.Add(drCurrentRow);
        ViewState["CurrentTable"] = dtCurrentTable;
        dtCurrentTable.Rows.RemoveAt(0)
        GridView1.DataSource = dtCurrentTable;
        GridView1.DataBind();
    }
