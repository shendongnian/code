    using System;
    using System.Data;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Month", typeof(int));
                dt.Rows.Add(1);
    
                if (dt.Columns.Contains("Month"))
                {
                    DataColumn originalDataColumn = dt.Columns["Month"];
                    DataColumn newDataColumn = dt.Columns.Add("NewMonth", typeof(string));
    
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[newDataColumn] = dr[originalDataColumn].ToString();
                    }
    
                    dt.Columns.Remove(originalDataColumn);
                    newDataColumn.ColumnName = "Month";
                }
            }
        }
    }
