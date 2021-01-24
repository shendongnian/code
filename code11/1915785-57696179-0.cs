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
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("GROUP", typeof(int));
                dt.Columns.Add("DATE", typeof(DateTime));
                dt.Rows.Add(new object[] {"A1212", 1, DateTime.Parse("1/1/2019")});
                dt.Rows.Add(new object[] {"A1212", 2, DateTime.Parse("1/1/2019")});
                dt.Rows.Add(new object[] {"A1213", 1, DateTime.Parse("3/1/2019")});
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                dt2.Columns.Add("GROUP", typeof(string));
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("ID")).ToList();
                foreach (var group in groups)
                {
                    dt2.Rows.Add(new object[] {
                        group.Key,
                        string.Join(",", group.Select(x => x.Field<int>("GROUP").ToString()).Distinct())
                    });
                }
            }
        }
      
    }
