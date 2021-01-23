DataTable dt1 = new DataTable();
DataTable dt2 = new DataTable();
dt2.Columns.Add("ColumnA", dt1.Columns["ColumnA"].DataType);
for (int i = 0; i &lt; dt1.Rows.Count; i++)
{
	dt2.Rows[i]["ColumnA"] = dt1.Rows[i]["ColumnA"];
}
