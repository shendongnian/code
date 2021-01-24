    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication131
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Value", typeof(int));
                dt.Columns.Add("Snapshot", typeof(DateTime));
                dt.Rows.Add(new object[] { 1, 1, DateTime.Parse("2019-03-07 20:00:04")});
                dt.Rows.Add(new object[] { 2, 2, DateTime.Parse("2019-03-07 20:01:15")});
                dt.Rows.Add(new object[] { 3, 1, DateTime.Parse("2019-03-07 20:01:23")});
                dt.Rows.Add(new object[] { 4, 3, DateTime.Parse("2019-03-07 20:01:45")});
                dt.Rows.Add(new object[] { 5, 5, DateTime.Parse("2019-03-07 20:02:10")});
                dt.Rows.Add(new object[] { 6, 7, DateTime.Parse("2019-03-07 20:02:45")});
                dt.Rows.Add(new object[] { 7, 1, DateTime.Parse("2019-03-07 20:03:10")});
                dt.Rows.Add(new object[] { 8, 0, DateTime.Parse("2019-03-07 20:04:30") });
                List<DataRow> results = dt.AsEnumerable()
                    .OrderBy(x => x.Field<DateTime>("Snapshot"))
                    .GroupBy(x => new DateTime(
                        x.Field<DateTime>("Snapshot").Year,
                        x.Field<DateTime>("Snapshot").Month,
                        x.Field<DateTime>("Snapshot").Day,
                        x.Field<DateTime>("Snapshot").Hour,
                        x.Field<DateTime>("Snapshot").Minute,
                        0
                        ))
                    .Select(x => x.First())
                    .ToList();
            }
        }
    }
