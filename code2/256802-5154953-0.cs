DataRow summary1 = dt.Rows[0], summary2 = dt.Rows[1], summary3 = new DataRow();
summary3[0] = "Summary3";
for(int i=1; i &lt; summary1.Table.Columns.Count; i++)
{
  try{
    summary3[i] = double.Parse(summary1[i].ToString()) - double.Parse(summary2[i].ToString())
  }catch{
    summary3[i] = "n/a";
  }
}
This code allows you to have a variable amount of DataColumn inside the DataRow
