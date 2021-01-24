cs
DataTable dt = new DataTable();
dt.Columns.Add("id", Type.GetType("System.Int32"));
dt.Columns.Add("group", Type.GetType("System.String"));
dt.Columns.Add("first", Type.GetType("System.String"));
dt.Columns.Add("second", Type.GetType("System.Int32"));
dt.Rows.Add(1, "Test1", "584", 12);
dt.Rows.Add(2, "Test2", "32", 123);
dt.Rows.Add(3, "Test3", "425", 54);
dt.Rows.Add(4, "Test1", "4", 755);
dt.Rows.Add(5, "Test5", "854", 879);
dt.Rows.Add(6, "Test2", "1", null);
dt.Rows.Add(7, "Test2", "999", 3);
You can then group and find the maximums (assuming that is what you mean by 'best') using Linq:
var group = dt.AsEnumerable().GroupBy(row => row.Field<string>("group")).Select(g => new
{
    group = g.Key,
    first = g.Max(row => int.Parse(row.Field<string>("first"))).ToString(),
    second = g.Max(row => row.Field<int?>("second") ?? 0)
}).ToList();
This gives you a list that matches your desired output.
I have assumed that a `null` value should be considered to be a value of 0. You can then put the values back into your original DataTable:
dt.Clear();
var rowCount = 1;
foreach (var x in group)
    dt.Rows.Add(rowCount++, x.group, x.first, x.second);
