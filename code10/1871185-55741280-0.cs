    System.Data.DataSet dataSet = null;
    var result = GenerateWhereInListFromData(dataSet.Tables.Cast<System.Data.DataTable>(), t => t.TableName, ",");
    System.Data.DataTable dataTable = null;
    result = GenerateWhereInListFromData(dataTable.Rows.Cast<System.Data.DataRow>(), t => t["SomeColumn"].ToString(), ",");
    result = GenerateWhereInListFromData(dataTable.Columns.Cast<System.Data.DataColumn>(), t => t.ColumnName, ",");
