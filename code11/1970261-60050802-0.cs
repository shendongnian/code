public void BulkInsert(DataTable employees)
{
    if (employees == null)
        throw new ArgumentNullException(nameof(employees), $"{nameof(employees)} is null.");
    using (var con = OpenConnection())
    using (var sbc = new SqlBulkCopy(con))
    {
        sbc.DestinationTableName = "HR.Employee";
        foreach (DataColumn column in employees.Columns)
            sbc.ColumnMappings.Add(column!.ColumnName, column.ColumnName);
        sbc.WriteToServer(employees);
    }
}
Note the `foreach (DataColumn column in employees.Columns)` loop. This is required so that it knows the column names are the same in the source and the target table. (If they're not the same, manually map them in the same fashion.)
Source: https://grauenwolf.github.io/DotNet-ORM-Cookbook/BulkInsert.htm#ado.net
