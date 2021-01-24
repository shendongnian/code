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
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("ORG", typeof(string));
                dt.Columns.Add("DES", typeof(string));
                dt.Columns.Add("A", typeof(int));
                dt.Columns.Add("B", typeof(int));
                dt.Rows.Add(new object[] { 101, "ABC", "KIL", 1, 5 });
                dt.Rows.Add(new object[] { 102, "XYZ", "LOU", 2, 6 });
                dt.Rows.Add(new object[] { 103, "MNO", "HYT", 3, 7 });
                dt.Rows.Add(new object[] { 104, "PQR", "HYT", 4, 8 });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(int));
                dt2.Columns.Add("ORG", typeof(string));
                dt2.Columns.Add("DES", typeof(string));
                dt2.Columns.Add("Type", typeof(string));
                dt2.Columns.Add("B", typeof(int));
                foreach (DataRow row in dt.AsEnumerable())
                {
                    dt2.Rows.Add(new object[] { row["ID"], row["ORG"], row["DES"], "A", row["A"] });
                    dt2.Rows.Add(new object[] { row["ID"], row["ORG"], row["DES"], "B", row["B"] });
                }
     
            }
        }
     
    }
