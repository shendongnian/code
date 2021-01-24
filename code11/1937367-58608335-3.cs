    private static void SplitCsv(string filePath, int numRows)
    {
        // Open csv file for reading
        using (var fileReader = File.OpenText(filePath))
        {
            using (var csv = new CsvReader(fileReader))
            {
                // Get all list of Row records
                var rows = csv
                    .GetRecords<Row>()
                    .ToList();
                for (var row = 0; row < rows.Count() / numRows; row++)
                {
                    // Extract chunk of rows using LINQ
                    var fileRows = rows
                        .Skip(row * numRows)
                        .Take(numRows);
                    // Write chunk to new csv file
                    using (var writer = new StreamWriter($@"PATH\\{$"file{row}"}", 
                        false, System.Text.Encoding.UTF8))
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
