    private static void SplitCsv(string filePath, int numRows)
    {
        using (var fileReader = File.OpenText(filePath))
        {
            using (var csv = new CsvReader(fileReader))
            {
                var rows = csv
                    .GetRecords<Row>()
                    .ToList();
                for (var row = 0; row < rows.Count() / numRows; row++)
                {
                    var fileRows = rows
                        .Skip(row * numRows)
                        .Take(numRows);
                    using (var writer = new StreamWriter($@"PATH\\{$"file{row}"}", false, System.Text.Encoding.UTF8))
                    {
                        using (var csvFile = new CsvWriter(writer))
                        {
                            csvFile.WriteRecords(fileRows);
                        }
                    }
                }
            }
        }
    }
