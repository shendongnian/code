    string filter = "Column1 = " + yourValue.ToString();
    string sortOrder = "Column3 desc";
    dtUpgradeFileInfo.DefaultView.RowFilter = filter;
    dtUpgradeFileInfo.DefaultView.Sort = sortOrder;
    DataRow myRow = null;
    DataTable filteredTable = dtUpgradeFileInfo.DefaultView.ToTable();
    if (filteredTable.Rows.Count > 0)
        myRow = filteredTable.Rows[0];
    if (myRow != null)
    {
        // get to work
    }
