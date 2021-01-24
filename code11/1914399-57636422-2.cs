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
                //create a 1000 strings from numbers starting at 1001
                string[] array = Enumerable.Range(1001, 1000).Select(x => "String : " + x.ToString()).ToArray();
                var pages = array.Select((x,i) => new {str = x, index = i})
                    .GroupBy(x => x.index  / 112)
                    .Select(x => x.ToArray())
                    .ToArray();
                var rows = pages
                    .SelectMany(x => x.GroupBy(y => y.index % 28)).Select(y => y.ToArray())
                    .ToArray();
                DataTable dt = new DataTable();
                dt.Columns.Add("Col A", typeof(string));
                dt.Columns.Add("Col B", typeof(string));
                dt.Columns.Add("Col C", typeof(string));
                dt.Columns.Add("Col D", typeof(string));
                foreach (var row in rows)
                {
                    DataRow newRow = dt.Rows.Add(new object[] { 
                        row[0].str, 
                        (row.Length > 1) ? (object)row[1].str : null,
                        (row.Length > 2) ? (object)row[2].str : null,
                        (row.Length > 3) ? (object)row[3].str : null
                    });
                }
            }
        }
    }
