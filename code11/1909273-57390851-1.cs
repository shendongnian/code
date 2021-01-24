    public class Program
    {
        public static void Main()
        {
            string filePath = "C:\\Users\\{User}\\Desktop\\sample.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            List<List<object>> rows = new List<List<object>>();
            List<object> row = new List<object>();
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
                            row.Clear();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var field = reader.GetValue(i);
                                if (field is int valueInt)
                                {
                                    row.Add(valueInt);
                                }
                                else if (field is bool valueBool)
                                {
                                    row.Add(valueBool);
                                }
                                else if (field is DateTime valueDate)
                                {
                                    //row.Add(valueDate); You can write any condition there
                                    row.Add(valueDate.Year);
                                }
                                else if (field is TimeSpan valueTime)
                                {
                                    row.Add(valueTime);
                                }
                                else if (field is string valueString)
                                {
                                    row.Add(valueString);
                                }
                                else if (field is null)
                                {
                                    row.Add(field);
                                }
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
