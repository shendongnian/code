        static void Main(string[] args)
        {
            DataTable dt = new DataTable("MainTable");
            var column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "value";
            // Add the Column to the DataColumnCollection.
            dt.Columns.Add(column);
            var stringList = new List<string> { "All people", "Finger Print", "MyRecord_v2", "MyRecordV2", "FPrint", "AXialis" };
            foreach (string s in stringList)
            {
                var row = dt.NewRow();
                row["value"] = s;
                dt.Rows.Add(row);
            }
            Console.WriteLine("Before Sort");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["value"]);
            }
            var query = dt.AsEnumerable().OrderBy(r => r.Field<string>("value"), StringComparer.Ordinal);
            Console.WriteLine("\r\nSorted");
            foreach (DataRow row in query)
            {
                Console.WriteLine(row["value"]);
            }
        }
