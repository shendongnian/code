    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    }
     public class MyClass
     {
         public DataTable CreateTable()
         {
             DataTable dt = new DataTable();
             string[] arr = { "1", "2", "3", "4", "5", "6", "7" };
    
             IEnumerable<IEnumerable<string>> rowValues = arr.Split(dt.Columns.Count);
             foreach (IEnumerable<string> rowValue in rowValues)
             {
                 DataRow row = dt.NewRow();
    
                 string[] cellValues = rowValue.ToArray();
                 for (int columnIndex = 0; columnIndex < cellValues.Length; columnIndex++)
                 {
                     // 'Safe'-check in case the original array didn't contain enough values. The cell value will remain 'null'
                     if (columnIndex < dt.Columns.Count)
                     {
                         row[columnIndex] = cellValues[columnIndex];
                     }
                 }
    
                 dt.Rows.Add(row);
             }
    
             return dt;
         }
     }
