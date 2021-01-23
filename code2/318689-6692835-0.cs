    public static string GetRowValue(DataRow row, string name) {
        if (!IsDBNull(row[name])) {
            return row[name].ToString();
        }
        return string.Empty;
    }
