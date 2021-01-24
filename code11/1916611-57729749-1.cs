C#
var groups = dt.AsEnumerable().GroupBy((sn) => sn.Field<string>("RE"))
            .Select((group) => new
            {
                RE = group.Key,
                DataRowList = group.OrderBy((dataRow) => dataRow.Field<string>("sn")).ToList()
            }).OrderBy(x => x.RE).ToList();
foreach (var group in groups)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
    foreach (var dataRow in group.DataRowList)
    {
        IEnumerable<string> fields = dataRow.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
        sb.AppendLine(string.Join(",", fields));
    }
    string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) 
        + "\\display-RE" + group.RE + ".csv";
    File.WriteAllText(fileName, sb.ToString());
}
