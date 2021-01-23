    var dateFormat = "yyyyMMdd"; // this could be pulled from app.config or some other config source
    foreach (var file in filestoextract)
    {
        var dateStr = file.Substring(file.Length-dateFormat.Length);
        if (ValidateDate(dateStr, dateFormat))
        {
            var id = file.Substring(0, file.Length - (dateFormat.Length+1));
            // do something with data
        }
        else
        {
            // handle invalid filename
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
