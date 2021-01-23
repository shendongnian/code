        static void Main(string[] args)
        {
            var cols = new string[] { "col1", "col2", "col3", "col4", "col5" };
            DataTable table = new DataTable();
            foreach (var col in cols)
                table.Columns.Add(col);
            table.Rows.Add(new object[] { "1", "2", "3", "4", "5" });
            table.Rows.Add(new object[] { "1", "2", "3", "4", "5" });
            table.Rows.Add(new object[] { "1", "2", "3", "4", "5" });
            table.Rows.Add(new object[] { "1", "2", "3", "4", "5" });
            table.Rows.Add(new object[] { "1", "2", "3", "4", "5" });
            foreach (var col in cols)
            {
                var results = from p in table.AsEnumerable()
                              select p[col];
                Console.WriteLine("*************************");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            Console.ReadLine();
        }
