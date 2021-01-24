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
                dt.Columns.Add("ParticipantId", typeof(int));
                dt.Columns.Add("Weight", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Rows.Add(new object[] {1, 86, DateTime.Parse("2020-01-30")});
                dt.Rows.Add(new object[] {1, 83, DateTime.Parse("2020-02-03")});
                dt.Rows.Add(new object[] {2, 98, DateTime.Parse("2020-01-20")});
                dt.Rows.Add(new object[] {2, 96, DateTime.Parse("2020-01-26")});
                dt.Rows.Add(new object[] {2, 75, DateTime.Parse("2020-02-06")});
                DateTime endDate = DateTime.Parse("2020-01-31");
                int sum = dt.AsEnumerable()
                    .Where(x => x.Field<DateTime>("Date") <= endDate)
                    .OrderByDescending(x => x.Field<DateTime>("Date"))
                    .GroupBy(x => x.Field<int>("ParticipantId"))
                    .Sum(x => x.First().Field<int>("Weight"));
                    
            }
        }
    }
