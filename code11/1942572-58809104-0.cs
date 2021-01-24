for (i = 0; i < dataGridView1.Rows.Count; ++i)
{
  var str = dataGridView1.Rows[i].Cells[2].Value;
  if( Int32.TryParse(str, out var parsed)
  {
     s += parsed;
  }
}
----
If you want to check the type of the column in a datatable you can check its `DataType`. 
foreach (var col in datatable1.Columns) 
{
      if ( col.DataType == typeof(System.Int16) || col.DataType == typeof(System.Int32)) // Or other types 
      {
           ....
