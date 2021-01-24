    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable mInfo = new DataTable();
                mInfo.Columns.Add("ID", typeof(int));
                mInfo.Columns.Add("Did", typeof(string));
                mInfo.Columns.Add("Mid", typeof(int));
                mInfo.Columns.Add("MName", typeof(string));
     
                mInfo.Rows.Add(new object[] {1, "D1", 1, "MName1"});
                mInfo.Rows.Add(new object[] {2, "D1", 2, "MName2"});
                mInfo.Rows.Add(new object[] {3, "D2", 1, "MName3"});
                mInfo.Rows.Add(new object[] {4, "D2", 2, "MName4"});
                mInfo.Rows.Add(new object[] {5, "D2", 3, "MName5"});
                DataTable vData = new DataTable();
                vData.Columns.Add("ID", typeof(int));
                vData.Columns.Add("Did", typeof(string));
                vData.Columns.Add("Mid", typeof(int));
                vData.Columns.Add("Value", typeof(decimal));
                vData.Columns.Add("DateTime", typeof(DateTime));
                vData.Rows.Add(new object[] { 1, "D1", 1, 10.25, DateTime.Parse("2018-04-15 17:33:22")});
                vData.Rows.Add(new object[] { 2, "D1", 2, 11.26, DateTime.Parse("2018-04-15 19:33:22")});
                vData.Rows.Add(new object[] { 3, "D2", 1, 12.30, DateTime.Parse("2018-04-15 22:33:22")});
                vData.Rows.Add(new object[] { 4, "D2", 2, 45.50, DateTime.Parse("2018-04-15 17:33:22")});
                vData.Rows.Add(new object[] { 5, "D2", 3, 50.40, DateTime.Parse("2018-04-15 19:33:22")});
                vData.Rows.Add(new object[] { 6, "D1", 2, 60.66, DateTime.Parse("2018-04-15 22:33:22")});
                vData.Rows.Add(new object[] { 6, "D2", 1, 60.41, DateTime.Parse("2018-04-15 19:33:22")});
                vData.Rows.Add(new object[] { 7, "D2", 1, 66.22, DateTime.Parse("2018-04-15 22:33:22")});
                vData.Rows.Add(new object[] { 8, "D2", 1, 70.65, DateTime.Parse("2018-04-15 23:33:22")});
                var results = vData.AsEnumerable().OrderBy(x => x.Field<DateTime>("DateTime"))
                    .GroupBy(x => new { Did = x.Field<string>("Did"), Mid = x.Field<int>("Mid") })
                    .Select(x => new
                    {
                        MName = mInfo.AsEnumerable().Where(y => (y.Field<string>("Did") == x.Key.Did) && (y.Field<int>("Mid") == x.Key.Mid)).FirstOrDefault().Field<string>("MName"),
                        OpeningValue = x.First().Field<decimal>("Value"),
                        ClosingValue = x.Last().Field<decimal>("Value")
                    }).ToList();
     
            }
        }
      
    }
