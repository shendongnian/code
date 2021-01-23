    var path = Server.MapPath(@"~\App_Data\Stats");
    Directory.CreateDirectory(path);
    path = Path.Combine(path, String.Format("{0}.csv", Guid.NewGuid()));
    
    using (var streamWriter = new StreamWriter(path))
    using (var csvWriter = new CsvHelper.CsvWriter(streamWriter))
    {
    	csvWriter.Configuration.Delimiter = csvWriter.Configuration.CultureInfo.TextInfo.ListSeparator;
    
    	csvWriter.WriteRecords(rounds);
    }
    
    return File(path, "text/csv", "Stats.csv");
