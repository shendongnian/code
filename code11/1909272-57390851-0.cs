    public class Program
    {
        public static async Task Main()
        {
            string filePath = "C:\\Users\\{User}\\Desktop\\sample.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            List<List<string>> rows = new List<List<string>>();
            // Excel Reader
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration
                {
                    FallbackEncoding = Encoding.GetEncoding(1252),
    
                }))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            List<string> row = new List<string>();
                            for (int i = 0; i <= reader.ResultsCount; i++)
                            {
                                row.Add(reader.GetString(i));
                            }
    
                            if (row.Any())
                            {
                                rows.Add(row);
                            }
                        }
                    } while (reader.NextResult());
    
                }
            }
            // CSV Writer
            using (var writer = new StreamWriter("C:\\Users\\{User}\\Desktop\\sample.csv"))
            using (var csv = new CsvWriter(writer))
            {
                // Write field by field
                foreach (var i in rows)
                {
                    foreach (var field in i)
                    {
                        csv.WriteField(field);
                    }
                    csv.NextRecord();
                }
            }
        }
    
    }
