    string cellValue = table.Rows[0].GetCellValueByName<string>("Column#2");
    public static class DataRowExtensions
    {
        public static T GetCellValueByName<T>(this DataRow row, string columnName)
        {
            int index = row.Table.Columns.IndexOf(columnName);
            return (index < 0 || index > row.ItemArray.Count()) 
                      ? default(T) 
                      : (T) row[index];        
        }
    }
