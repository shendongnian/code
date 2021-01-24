DataTable table = new DataTable();
table.Columns.Add("Ref1", typeof(int));
table.Columns.Add("ItemNo", typeof(int));
table.Columns.Add("ItemDesc", typeof(string));
table.Rows.Add(1, 12345, "Test");
table.Rows.Add(1, 12346, "Test2");
table.Rows.Add(1, 12347, "Test3");
table.Rows.Add(2, 12345, "Test");
DataTable tableNew = new DataTable();
tableNew.Columns.Add("Ref1", typeof(int));
var result = table.AsEnumerable().GroupBy(x => x.Field<int>("Ref1"));
var max = result.Max(x => x.Count());
for (int i = 1; i <= max; i++)
{
    tableNew.Columns.Add($"ItemNo{i}", typeof(int));
}
foreach (var group in result)
{
    var newRow = tableNew.NewRow();
    newRow.SetField<int>("Ref1", group.Key);
    var itemNo = 1;
    foreach(var row in group)
    {
        var val = row.Field<int>("ItemNo");
        newRow.SetField<int>($"ItemNo{itemNo}", val);
        itemNo++;
    }
    tableNew.Rows.Add(newRow);
}
I would advise to move parts of the logic to an SQL query if the data comes from a database
