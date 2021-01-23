    public static class DataTableExtension
    {
        public static IEnumerable<IEnumerable<KeyValuePair<string, object>>> Items(this DataTable table)
        {
            var columns = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            foreach (DataRow row in table.Rows)
            {
                yield return columns.Select(c => new KeyValuePair<string, object>(c, row[c]));
            }
        }
    }
    static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Last Name");
            table.Columns.Add("First Name");
            table.Rows.Add("Tim", "Taylor");
            table.Rows.Add("John", "Adams");
            foreach (var row in table.Items())
            {
                foreach (var col in row)
                {
                    Console.WriteLine("{0}, {1}\t", col.Key, col.Value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
