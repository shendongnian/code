    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("C1", typeof(string));
                dt1.Columns.Add("C2", typeof(string));
                dt1.Columns.Add("C3", typeof(int));
                dt1.Rows.Add(new object[] { "A", "AA", 4});
                dt1.Rows.Add(new object[] { null, "BB", 6});
                dt1.Rows.Add(new object[] { "B", "CC", 3});
                dt1.Rows.Add(new object[] { null, "DD", 3});
                dt1.Rows.Add(new object[] { null, "EE", 4});
                dt1.Rows.Add(new object[] { "C", "FF", 5});
                dt1.Rows.Add(new object[] { null, "GG", 5});
                //replace nulls in column 1 with actual values
                string previous = "";
                foreach(DataRow row in dt1.AsEnumerable())
                {
                    if (row.Field<string>("C1") == null)
                    {
                        row["C1"] = previous;
                    }
                    else
                    {
                        previous = row.Field<string>("C1");
                    }
                }
                DataTable dt2 = dt1.Clone();
                var groups = dt1.AsEnumerable().GroupBy(x => x.Field<string>("C1")).ToList();
                foreach (var group in groups)
                {
                    dt2.Rows.Add(new object[] {
                        group.Key,
                        string.Join(",", group.Select(x => x.Field<string>("C2"))),
                        group.Select(x => x.Field<int>("C3")).Sum()
                    });
                }
            }
        }
    }
