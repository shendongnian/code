DataColumn column;
//Repeat this chunk for each column, changing DataType and ColumnName as neccessary
column = new DataColumn();
column.DataType = Type.GetType("System.String");
column.ColumnName = "col1";
myDataTable.Columns.Add(column);
This makes the ImportRow() method function as expected to.
