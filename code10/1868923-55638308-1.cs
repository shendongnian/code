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
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("foo", typeof(int));
                dt.Columns.Add("bar", typeof(int));
                dt.Rows.Add(new object[] { 0 , 321 , 33  });
                dt.Rows.Add(new object[] { 1 , 100 , 4  });
                dt.Rows.Add(new object[] { 2 , 355 , 23  });
                List<int> results = dt.AsEnumerable().Select(x => x.Field<int>("foo")).ToList();
            }
        }
    }
