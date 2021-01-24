DataTable logDataTable = new DataTable();
for (var index = 0; index < systemLog.LogEntries.Count; index++)
{
    var entry = systemLog.LogEntries[index];
    foreach (var logDetailsEntity in entry.Name)
    {
        if (logDataTable.Columns.Contains(logDetailsEntity.Header)) continue;
        logDataTable.Columns.Add(logDetailsEntity.Header);
    }
    logDataTable.Rows.Add();
    foreach (var logDetailsEntity in entry.Name)
    {
        logDataTable.Rows[index][logDetailsEntity.Header] = logDetailsEntity.Details;
    }
}
MainDataGrid.ItemsSource = logDataTable.DefaultView;
