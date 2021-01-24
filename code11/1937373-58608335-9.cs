    private static void SplitCsv(string source, string dest, int numRows)
    {
        // Open CSV file for reading
        using (var fileReader = File.OpenText(source))
        {
            using (var csv = new CsvReader(fileReader))
            {
                // Collect all rows
                var rows = csv
                    .GetRecords<Row>()
                    .ToList();
                // Iterate rows in chunks
                for (var row = 0; row < rows.Count() / numRows; row++)
                {
                    // Extract chunks using LINQ
                    var fileRows = rows
                        .Skip(row * numRows)
                        .Take(numRows);
                    // Create output path
                    var outputPath = Path.Combine(dest, $"file{row}");
                    // Write chunk to file
                    using (var writer = new StreamWriter(outputPath, 
                        false, 
                        System.Text.Encoding.UTF8))
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
