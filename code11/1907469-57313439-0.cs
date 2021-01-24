    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication123
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Property 1", typeof(string));
                dt.Columns.Add("Property 2", typeof(int));
                dt.Columns.Add("Property 3", typeof(int));
                dt.Rows.Add (new object[] { "AAA", 100,1000});
                dt.Rows.Add (new object[] { "AAA", 50,500});
                dt.Rows.Add (new object[] { "AAA", 10,800});
                dt.Rows.Add (new object[] { "BBB", 5,70});
                dt.Rows.Add (new object[] { "BBB", 20,20});
                dt.Rows.Add (new object[] { "BBB", 18,11});
                dt.Rows.Add (new object[] { "CCC", 10,13});
                dt.Rows.Add (new object[] { "CCC", 10,445});
                dt.Rows.Add (new object[] { "CCC", 5,1000});
                dt.Rows.Add (new object[] { "DDD", 0,100});
                dt.Rows.Add (new object[] { "DDD", 0,100});
                dt.Rows.Add (new object[] { "DDD", 0,100});
                DataTable results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Property 1")).Select(x => AddRowData(x.First(), x.ToArray())).CopyToDataTable();
                    
            }
            static DataRow AddRowData(DataRow firstRow, DataRow[] allRows)
            {
                for (int col = 1; col < firstRow.ItemArray.Count(); col++)
                {
                    firstRow[col] = allRows.Sum(x => x.Field<int>(col));
                }
                return firstRow;
            }
        }
     
    }
