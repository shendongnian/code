    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Prod", typeof(string));
                dt.Columns.Add("Qty", typeof(int));
     
                dt.Rows.Add(new object[] {DateTime.Parse("06/01/2018"), "ABC", 10});
                dt.Rows.Add(new object[] {DateTime.Parse("06/02/2018"), "ABC", 5});
                dt.Rows.Add(new object[] {DateTime.Parse("06/03/2018"), "ABC", 3});
                dt.Rows.Add(new object[] {DateTime.Parse("06/01/2018"), "DEF", 2});
                dt.Rows.Add(new object[] {DateTime.Parse("06/02/2018"), "DEF", 8});
                dt.Rows.Add(new object[] {DateTime.Parse("06/03/2018"), "DEF", 11});
                dt.Rows.Add(new object[] {DateTime.Parse("06/01/2018"), "GHI", 1});
                string[] uniqueProducts = dt.AsEnumerable().Select(x => x.Field<string>("Prod")).OrderBy(x => x).Distinct().ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Date", typeof(DateTime));
                foreach (string prod in uniqueProducts)
                {
                    pivot.Columns.Add(prod, typeof(int));
                }
                var groups = dt.AsEnumerable().OrderBy(x => x.Field<DateTime>("Date")).GroupBy(x => x.Field<DateTime>("Date").Date).ToList();
                foreach(var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["Date"] = group.Key;
                    foreach (DataRow row in group)
                    {
                        newRow[row.Field<string>("Prod")] = row.Field<int>("Qty");
                    }
                }
     
            }
        }
     
    }
