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
                DataTable table_A = new DataTable();
                table_A.Columns.Add("ID", typeof(int));
                table_A.Columns.Add("Activity", typeof(string));
                table_A.Rows.Add(new object[] { 1, "Change Oil"});
                table_A.Rows.Add(new object[] { 2, "Change Airfilter"});
                table_A.Rows.Add(new object[] { 3, "Change Brake Fluid"});
                DataTable table_B = new DataTable();
                table_B.Columns.Add("ID", typeof(int));
                table_B.Columns.Add("ActivityID", typeof(string));
                table_B.Columns.Add("CompletedBy", typeof(string));
                table_B.Rows.Add(new object[] { 1, 1, "john@auto.com"});
                table_B.Rows.Add(new object[] { 2, 1, "sally@auto.com"});
                table_B.Rows.Add(new object[] { 3, 3, "john@auto.com"});
                var groups = (from a in table_A.AsEnumerable()
                              join b in table_B.AsEnumerable() on a.Field<int>("ID") equals b.Field<int>("ID")
                              select new { a = a, b = b})
                              .GroupBy(x => x.b.Field<string>("CompletedBy"))
                              .ToList();
            }
        }
    }
