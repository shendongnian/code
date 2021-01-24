var z = x.AsEnumerable()
         .Where(s => s.Field<string>("Symbol") == "A")
         .AsDataView()
         .ToTable();
## 2. `Clone()` -> `CopyToDataTable<T>(IEnumerable<T>, DataTable, LoadOption)`
You can use [Clone](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.clone?view=netframework-4.8) which '*Clones the structure of the DataTable, including all DataTable schemas and constraints.*' followed by `CopyToDataTable`, but the one version that takes the target table. 
var z = x.Clone();
x.AsEnumerable()
   .Where(s => s.Field<string>("Symbol") == "A")
   .CopyToDataTable(z,LoadOption.OverwriteChanges);
# Test
(your dt definition here) 
Console.WriteLine(x.Columns["utcDT"].DateTimeMode);
var y = x.AsEnumerable()
        .Where(s => s.Field<string>("Symbol") == "A")
        .CopyToDataTable<DataRow>();
Console.WriteLine(y.Columns["utcDT"].DateTimeMode);
var z = x.AsEnumerable()
        .Where(s => s.Field<string>("Symbol") == "A")
        .AsDataView()
        .ToTable();
Console.WriteLine(z.Columns["utcDT"].DateTimeMode);
var a = x.Clone();
x.AsEnumerable()
        .Where(s => s.Field<string>("Symbol") == "A")
        .CopyToDataTable(a,LoadOption.OverwriteChanges);
Console.WriteLine(a.Columns["utcDT"].DateTimeMode);
## Output
Utc
UnspecifiedLocal
Utc
Utc
