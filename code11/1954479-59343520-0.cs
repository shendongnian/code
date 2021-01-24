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
                dt1.Columns.Add("ID1", typeof(string));
                dt1.Columns.Add("ID2", typeof(string));
                dt1.Columns.Add("SKU", typeof(string));
                dt1.Columns.Add("Revenue", typeof(int));
                dt1.Columns.Add("Score", typeof(int));
                dt1.Rows.Add(new object[] { "A", "a", "s1", 1000, 100});
                dt1.Rows.Add(new object[] { "A", "a", "s2", 2000, 200 });
                dt1.Rows.Add(new object[] { "A", "a", "s3", 1500, 150 });
                dt1.Rows.Add(new object[] { "B", "b", "s1", 3000, 55 });
                dt1.Rows.Add(new object[] { "B", "b", "s2", 200, 67 });
                dt1.Rows.Add(new object[] { "B", "b", "s4", 1000, 99 });
                var groups = dt1.AsEnumerable()
                    .GroupBy(x => new { ID1 = x.Field<string>("ID1"), ID2 = x.Field<string>("ID2"),  })
                    .OrderByDescending(x => x.Sum(y => y.Field<int>("Score")))
                    .Select((x, i) => new { SKU = string.Join(",", x.Select(y => y.Field<string>("SKU")).OrderBy(y => y).Distinct()), Rank = i + 1, OCCURANCE = x.Count(), REVENUE = x.Sum(y => y.Field<int>("REVENUE")) })
                    .ToList();
            }
        }
    }
