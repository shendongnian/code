    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable table = new DataTable();
    
                // Create the first column.
                DataColumn textColumn = new DataColumn();
                textColumn.DataType = System.Type.GetType("System.String");
                textColumn.ColumnName = "text";
    
                // Create the second column.
                DataColumn priceColumn = new DataColumn();
                priceColumn.DataType = System.Type.GetType("System.Decimal");
                priceColumn.ColumnName = "price";
                priceColumn.DefaultValue = 50;
    
                // Add columns to DataTable.
                table.Columns.Add(textColumn);
                table.Columns.Add(priceColumn);
    
                DataRow row = table.NewRow();
                row["text"] = "bc";
                table.Rows.Add(row);
    
                DataRow[] rows = table.Select("text not like 'a%'");
                Console.WriteLine(rows.Count());
            }
        }
    }
