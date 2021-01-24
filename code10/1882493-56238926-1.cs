    using (var writer = new StreamWriter(@"C:\Users\NPandian\Desktop\test.csv", false, System.Text.Encoding.UTF8))
    using (var csvWriter = new CsvWriter(writer))
    {
        var ReportName = "Test Class";
        csvWriter.Configuration.RegisterClassMap(classMap);
        //Doesn't matter where this is called as long as it is before `WriteRecords`
        writer.WriteLine($"ReportName:, {ReportName}");
        csvWriter.WriteRecords(records);
        //No need to explicitly close, that's what `using` is for
    }
