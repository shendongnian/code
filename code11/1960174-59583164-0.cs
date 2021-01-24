    using (var sr = new StreamReader(filePath))
    using (CsvReader csv = new CsvReader(sr, false, delimiter, '\"', '\0', '\0', ValueTrimmingOptions.All, 65536))
    {
        bulkCopy.WriteToServer(csv);
    }
