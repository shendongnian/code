c#
//Borrowed from @jdweng
DataTable dt1 = new DataTable();
dt1.Columns.Add("C1", typeof(string));
dt1.Columns.Add("C2", typeof(string));
dt1.Columns.Add("C3", typeof(int));
DataTable dt2 = dt1.Clone();
dt1.Rows.Add(new object[] { "A", "AA", 3 });
dt1.Rows.Add(new object[] { null, "BB", 6 });
dt1.Rows.Add(new object[] { "B", "CC", 3 });
dt1.Rows.Add(new object[] { null, "DD", 3 });
dt1.Rows.Add(new object[] { null, "EE", 4 });
dt1.Rows.Add(new object[] { "C", "FF", 5 });
dt1.Rows.Add(new object[] { null, "GG", 6 });
var rows = dt1.Rows.Cast<DataRow>().AsEnumerable();
foreach (var row in rows.Where(r => r.Field<string>("C1") != null))
{
    var indx = dt1.Rows.IndexOf(row) + 1;
    var q = rows.Skip(indx)
        .TakeWhile(t => t.Field<string>("C1") == null)
        .GroupBy(g => g.Field<string>("C1"))
        .Select(g => new
        {
            C1 = row.Field<string>("C1"),
            C2 = $"{row.Field<string>("C2")}, {string.Join(", ", g.Select(s => s.Field<string>("C2")))}",
            C3 = row.Field<int>("C3") + g.Sum(s => s.Field<int>("C3")),
        });
    var r = q.FirstOrDefault();
    if(r != null)
        dt2.Rows.Add(r.C1, r.C2, r.C3);                
}
dataGridView1.DataSource = null;
dataGridView1.DataSource = dt2;
Happy 2020 for all.
