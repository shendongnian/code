List<string> headersToSkip = new List<string>() { "A", "B" };
foreach(var header in headersToSkip)
{
   dataTable.Columns.Remove(header);
}
To Rename Columns,			
Dictionary<string, string> headersToReplace = new Dictionary<string, string>() { { "C", "D" } };
foreach(var header in headersToReplace)
{
	dataTable.Columns[header.Key].ColumnName = header.Value;
}
