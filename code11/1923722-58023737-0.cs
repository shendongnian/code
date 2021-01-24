    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
    var dt = new DataTable();
    dt.Columns.Add("DateFrm", typeof(DateTime));
    dt.Columns.Add("DateTo", typeof(DateTime));
    dt.Columns.Add("ivalue", typeof(int));
    dt.Rows.Add("2019-01-01", "2019-02-01", 10);
    dt.Rows.Add("2019-02-01", "2019-03-01", 11);
    dt.Rows.Add("2019-03-01", "2019-04-01", 12);
    var searchFor = new DateTime(2019, 2, 9);
    DataRow[] results = dt.AsEnumerable().Where(row =>
        searchFor >= row.Field<DateTime>("DateFrm") &&
        searchFor < row.Field<DateTime>("DateTo")).ToArray();
    foreach (var result in results)
        Console.WriteLine(String.Join(", ", result.ItemArray));
