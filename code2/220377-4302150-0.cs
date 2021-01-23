    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ConsoleApplication1
{
    class Program
    {
        public static DataTable GetDataTable()
        {
            //Create a new DataTable object
            DataTable objDataTable = new DataTable();
            //Create three columns with string as their type
            objDataTable.Columns.Add("Column 1", typeof(string));
            objDataTable.Columns.Add("Column 2", typeof(string));
            objDataTable.Columns.Add("Column 3", typeof(string));
            //Adding some data in the rows of this DataTable
            objDataTable.Rows.Add(new string[] { "Row1 - Column1", "Row1 - Column2", "Row1 - Column3" });
            objDataTable.Rows.Add(new string[] { "Row2 - Column1", "Row2 - Column2", "Row2 - Column3" });
            objDataTable.Rows.Add(new string[] { "Row3 - Column1", "Row3 - Column2", "Row3 - Column3" });
            return objDataTable;
        }
        static void Main(string[] args)
        {
            foreach (DataRow row in GetDataTable().Rows)
            {
                object cellData = row["Column 1"];
                Console.WriteLine(cellData);
            }
        }
    }
}
