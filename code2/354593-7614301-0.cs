    using System;
    using System.Data;
    
    class Test
    {
        static void Main()
        {
            long x = 10;
            var table = new DataTable();
            table.Columns.Add(new DataColumn("RID", Type.GetType("System.Int64")));
            table.Rows.Add(x);
        }
    }
