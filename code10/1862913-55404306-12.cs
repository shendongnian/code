    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    
        public static void FillDataTable<T>(this DataTable dataTable, T[] input)
        {
            IEnumerable<IEnumerable<T>> rowValues = input.Split(dataTable.Columns.Count);
            foreach (IEnumerable<T> rowValue in rowValues)
            {
                DataRow row = dataTable.NewRow();
    
                T[] cellValues = rowValue.ToArray();
                for (int columnIndex = 0; columnIndex < cellValues.Length; columnIndex++)
                {
                    // 'Safe'-check in case the original array didn't contain enough values. The cell value will remain 'null'
                    if (columnIndex < dataTable.Columns.Count)
                    {
                        row[columnIndex] = cellValues[columnIndex];
                    }
                }
    
                dataTable.Rows.Add(row);
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8 };
    
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("v1");
            dataTable.Columns.Add("v2");
            dataTable.Columns.Add("v3");
            dataTable.Columns.Add("v4");
    
            dataTable.FillDataTable(input);    
        }
    }
