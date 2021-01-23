    var dateFormat = "yyyyMMdd"; // this could be pulled from app.config or some other config source   
    for (int i = 0; i <= filestoextract.count; i++) {
        var dateStr = filestoextract[i].Substring(filestoextract[i].Length-dateFormat.Length);
        if (ValidateDate(dateStr, dateFormat))
        {
            var id = filestoextract[i].Substring(0, filestoextract[i].Length-(dateFormat.Length+1));
        }
    }
    public bool ValidateDate(stirng date, string date_format)
    {
        try
        {
            DateTime.ParseExact(date, date_format, DateTimeFormatInfo.InvariantInfo);
        }
        catch
        {
            return false;
        }
        return true;    
    }
