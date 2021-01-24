DataTable table = new DataTable();
table.Columns.Add("col1", typeof(int));
table.Columns.Add("col2", typeof(int));
table.Columns.Add("col3", typeof(int));
table.Columns.Add("col4", typeof(int));
table.Rows.Add(25 ,10,2,10);
table.Rows.Add(22, 11, 12, 14);
table.Rows.Add(13, 22, 3, 55);
table.Rows.Add(3, 4, 12, 5);
DataTable table2 = new DataTable();
table2.Columns.Add("col1", typeof(int));
foreach (DataRow row in table.Rows)
{
  foreach (DataColumn col in table.Columns)
  {
    table2.Rows.Add(int.Parse((row[col].ToString())));
  }
}
Result 
25
10
2
10
22
11
12
14
13
22
3
55
3
4
12
5
