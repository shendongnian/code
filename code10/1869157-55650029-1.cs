using System;
using System.Data;
using System.Linq;
using System.Text;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = SampleData();
            // Prepare the column formats
            int nCols = dt.Columns.Count;
            var dataWidths = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName.Length).ToList();
            foreach (DataRow d in dt.Rows)
            {
                for (int i = 0; i < nCols; i++)
                {
                    dataWidths[i] = Math.Max(dataWidths[i], d.ItemArray[i].ToString().Length);
                }
            }
            var colFormats = dataWidths.Select(x => $"{{0,{-x}}}").ToList();
            //
            var sb = new StringBuilder();
            // Add the column names
            sb.AppendLine(string.Join(" ", dt.Columns.Cast<DataColumn>().Select((x, i) => string.Format(colFormats[i], x.ColumnName))));
            // Add in the data
            foreach (DataRow d in dt.Rows)
            {
                sb.AppendLine(string.Join(" ", d.ItemArray.Select((x, i) => string.Format(colFormats[i], x))));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
        static DataTable SampleData()
        {
            DataTable sdt = new DataTable();
            string[] cn = "ARCHIVE DBDATETIME NEXTDOCID HIGHESTDISK SYSTEMTYPE FLAGS VERSION SINGLEUSER".Split(' ');
            foreach (string n in cn)
            {
                sdt.Columns.Add(n);
            }
            DataRow drn = sdt.NewRow();
            drn["ARCHIVE"] = "Hello";
            drn["DBDATETIME"] = 1316859;
            drn["NEXTDOCID"] = 1;
            drn["HIGHESTDISK"] = "Nothing";
            drn["SYSTEMTYPE"] = 1;
            drn["FLAGS"] = "ABC";
            drn["VERSION"] = "Hello";
            drn["SINGLEUSER"] = 256;
            sdt.Rows.Add(drn);
            drn = sdt.NewRow();
            drn["ARCHIVE"] = "Value longer than header";
            // No value for drn["DBDATETIME"] etc.
            drn["SINGLEUSER"] = 256;
            sdt.Rows.Add(drn);
            return sdt;
        }
    }
}
Sample output:
