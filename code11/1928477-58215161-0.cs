    static void Main(string[] args)
    {
        var filePath = @"C:\Users\xxx\Downloads\test.xlsx";
        var fileInfo = new FileInfo(filePath);
        var package = new ExcelPackage(fileInfo);
        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
        var properties = GetPropertiesFromExcelFirstLine(worksheet);
        var i = 2;
        var objectsList = new List<object>();
        while (worksheet.Cells[i, 1].Value != null && (worksheet.Cells[i, 1].Value?.ToString() != ""))
        {
            objectsList.Add(GetObjectByLineNumber(worksheet, i, properties));
            i++;
        }
        var json = JsonConvert.SerializeObject(objectsList);
    }
    static List<string> GetPropertiesFromExcelFirstLine(ExcelWorksheet worksheet)
    {
        var list = new List<string>();
        var i = 1;
        while (worksheet.Cells[1, i].Value != null && (worksheet.Cells[1, i].Value?.ToString() != ""))
        {
            list.Add(worksheet.Cells[1, i].Value?.ToString());
            i++;
        }
        return list;
    }
    static ExpandoObject GetObjectByLineNumber(ExcelWorksheet worksheet, int line, List<string> objectProperties)
    {
        var obj = new ExpandoObject();
        
        for (int i = 1; i <= objectProperties.Count; i++)
        {
            AddProperty(obj, objectProperties[i - 1], worksheet.Cells[line, i].Value?.ToString());
        }
        return obj;
    }
    public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
    {
        var expandoDict = expando as IDictionary<string, object>;
        if (expandoDict.ContainsKey(propertyName))
            expandoDict[propertyName] = propertyValue;
        else
            expandoDict.Add(propertyName, propertyValue);
    }
