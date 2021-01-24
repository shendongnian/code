     public void ExportToCsv<T>(string filename, ImmutableArray<T> objects)
            {
                using (var writer = File.CreateText(filename))
                {
                    var csv = new CsvWriter(writer);
                    csv.WriteRecords(objects);
                }
            }
