    public class Person
    {
        public string First { get; set; }
        public string Last { get; set; }
        public DateTime Birthday { get; set; }
    }
    private DataTable GenerateDataTable<T>(int rows)
    {
        var datatable = new DataTable(typeof(T).Name);
        typeof(T).GetProperties().ToList().ForEach(
            x => datatable.Columns.Add(x.Name));
        Builder<T>.CreateListOfSize(rows).Build()
            .ToList().ForEach(
                x => datatable.LoadDataRow(x.GetType().GetProperties().Select(
                    y => y.GetValue(x, null)).ToArray(), true));
        return datatable;
    }
    var dataset = new DataSet();
    dataset.Tables.AddRange(new[]{
            GenerateDataTable<Person>(50),
            GenerateDataTable<Dog>(100)});
