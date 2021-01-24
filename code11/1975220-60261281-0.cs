    public void WriteRecord(List<T> data, string filename)
    {
        using (TextWriter writer = new StreamWriter(filename))
        {
            using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "yyyy/MM/dd HH:mm:ss.fff" };
                csv.WriteRecords(data);
                writer.Flush();
            }
       }
    }
