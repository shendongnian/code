    public class LstLog
    {
        private Dictionary<string, string> columnDictionary = new Dictionary<string, string>();
        // Methods
        public LstLog(String column1, String column2, String column3, String column4)
        {
            columnDictionary["column1"] = column1;
            columnDictionary["column2"] = column1;
            columnDictionary["column3"] = column1;
            columnDictionary["column4"] = column1;
        }
        public string GetColumnValue(string columnName)
        {
            if(columnDictionary.ContainsKey(columnName)
                return columnDictionary[columnName];
            else 
                return null;
        }
    }
