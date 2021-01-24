    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication137
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Col1", typeof(string));
                dt.Columns.Add("UserID", typeof(string));
                dt.Columns.Add("RNo", typeof(int));
                dt.Rows.Add(new object[] {"ABC", "FName1.SName1", 10});
                dt.Rows.Add(new object[] {"PQR", "FName2.SName2", 20});
                dt.Rows.Add(new object[] {"XYZ", "FName3.SName3", 30});
                var dt2 = dt.AsEnumerable()
                    .SelectMany(x => CloneRow(x)).CopyToDataTable();
            }
            public static  List<DataRow> CloneRow(DataRow row)
            {
                DataTable dt = row.Table.Clone();
                
                foreach (string id in row.Field<string>("UserID").Split(new char[] { '.' }))
                {
                    dt.Rows.Add(new object[] { row["Col1"], id , row["RNo"]});
                }
                return dt.AsEnumerable().ToList();
            }
     
        } 
    }
