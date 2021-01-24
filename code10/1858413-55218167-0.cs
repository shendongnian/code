    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication106
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Month", typeof(DateTime));
                dt.Columns.Add("Volume", typeof(int));
                  
                dt.Rows.Add(new object[] {"A", DateTime.ParseExact("2019-01", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 1400});
                dt.Rows.Add(new object[] { "B", DateTime.ParseExact("2019-01", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 1100 });
                dt.Rows.Add(new object[] { "B", DateTime.ParseExact("2019-02", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 400 });
                dt.Rows.Add(new object[] { "C", DateTime.ParseExact("2019-01", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 6500 });
                dt.Rows.Add(new object[] { "B", DateTime.ParseExact("2019-03", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 6500 });
                dt.Rows.Add(new object[] { "A", DateTime.ParseExact("2019-02", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 500 });
                dt.Rows.Add(new object[] { "C", DateTime.ParseExact("2019-02", "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture), 35 });
                DateTime[] dates = dt.AsEnumerable().Select(x => x.Field<DateTime>("Month")).Distinct().OrderBy(x => x).ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Name", typeof(string));
                foreach (DateTime date in dates)
                {
                    pivot.Columns.Add(date.ToString("yyyy-MM"), typeof(int));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("Name")).ToList();
                foreach(var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["Name"] = group.Key;
                    foreach(DataRow row in group)
                    {
                        newRow[row.Field<DateTime>("Month").ToString("yyyy-MM")] = row.Field<int>("Volume");
                    }
                }
            }
     
        }
     
    }
