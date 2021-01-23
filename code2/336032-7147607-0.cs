    public CSVEscape(String columnData)
    {
        if(columnData.Contains("\n") || columnData.Contains("\r") || columnData.Contains("\"") || columnData.Contains(","))
        {
            return "\"" + columnData.Replace("\"", "\"\"") + "\"";
        }
        return columnData;
    }
